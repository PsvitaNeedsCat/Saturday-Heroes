using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BasicBoss : MonoBehaviour
{
    public UIBar m_healthBar;
    public Image m_healthBarChase;
    public Animator m_animator;
    public Image m_diamondEffectIndicator;
    public Image m_diamondEffectDurationIndicator;
    public Color m_diamondEffectColor;

    public enum EState
    {
        init,
        idle,
        attacking,
        rippingReality,
        wormholeAttack,
    };
    [HideInInspector] public EState m_state = EState.init;

    [Header("Basic Attack")]
    private float m_fireRate = 1.0f;
    private float m_firingTimer = 0.0f;
    private EDamageType[] m_projHitTypes =
    {
        EDamageType.player,
    };
    private GameObject m_projectilePrefab = null;
    [SerializeField] private Transform[] m_projectileSpawns = new Transform[] { };
    private float m_basicAttackLength = 10.0f;

    [Header("Wormhole Attack")]
    private Wormhole m_wormhole = null;
    private GameObject m_wormholePrefab = null;
    [SerializeField] private Transform m_wormholeSpawn = null;
    private GameObject m_wormholeProjectilePrefab = null;

    [Header("Components")]
    [HideInInspector] public HealthComponent m_healthComp;

    private bool m_diamondDebuff;
    private float m_diamondDebuffDuration;
    private const float m_kDiamondDebuffMaxDuration = 5f;
    private SpriteRenderer m_spriteRenderer = null;

    private void Awake()
    {
        m_projectilePrefab = Resources.Load<GameObject>("Prefabs/Bosses/Basic Boss/BossProjectile");

        m_spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();

        m_wormholePrefab = Resources.Load<GameObject>("Prefabs/Bosses/Basic Boss/Wormhole");
        m_wormholeProjectilePrefab = Resources.Load<GameObject>("Prefabs/Bosses/Basic Boss/WormholeProjectile");

        m_healthComp = GetComponent<HealthComponent>();
        m_healthComp.Init(50, OnHurt, OnDeath);
    }

    private void Update()
    {
        switch (m_state)
        {
            case EState.init:
                {
                    InitState();
                    break;
                }

            case EState.idle:
                {
                    IdleState();
                    break;
                }

            case EState.attacking:
                {
                    AttackingState();
                    break;
                }

            case EState.rippingReality:
                {
                    RippingReality();
                    break;
                }

            case EState.wormholeAttack:
                {
                    WormholeAttack();
                    break;
                }

            default:
                {
                    break;
                }
        }
        UpdateDebuff();
    }

    // Called every frame the boss is in init state
    private void InitState()
    {
        AudioManager.Instance.PlaySound("roar");

        StartCoroutine(Wait(2.8f, () => m_state = EState.rippingReality));

        if (m_state == EState.init)
        {
            m_state = EState.idle;
        }
    }

    public IEnumerator Wait(float _seconds, System.Action _action)
    {
        yield return new WaitForSeconds(_seconds);

        _action.Invoke();
    }

    // Called every frame the boss is idle
    private void IdleState()
    {
        // Doesn't do anything in idle
    }

    // Called every frame the boss is attacking
    private void AttackingState()
    {
        m_firingTimer += Time.deltaTime * (m_diamondDebuff ? 0.5f : 1.0f);

        if (m_firingTimer >= m_fireRate)
        {
            m_firingTimer -= m_fireRate;

            FireProjectile();
        }
    }

    // Called every frame the boss is attacking
    private void RippingReality()
    {
        // Play animation
        m_animator.SetTrigger("Cut");
        AudioManager.Instance.PlaySound("riftAppear");

        StartCoroutine(Wait(1.0f, () =>
        {
            // Spawn reality attack
            m_wormhole = Instantiate(m_wormholePrefab, m_wormholeSpawn.position, Quaternion.identity).GetComponent<Wormhole>();

            m_wormhole.m_boss = this;

            m_wormhole.Init(m_wormholeProjectilePrefab);

            m_state = EState.wormholeAttack;
        }));

        if (m_state == EState.rippingReality)
        {
            m_state = EState.idle;
        }
    }

    // Called every frame the boss is attacking
    private void WormholeAttack()
    {
        m_wormhole.UpdateAttack();
    }

    // Fires one projectile
    private void FireProjectile()
    {
        Quaternion rotation = Quaternion.LookRotation(transform.forward);
        int positionIndex = Random.Range(0, m_projectileSpawns.Length - 1);
        Vector3 position = m_projectileSpawns[positionIndex].position;
        Projectile proj = Instantiate(m_projectilePrefab, position, rotation).GetComponent<Projectile>();

        proj.Init(m_projHitTypes, 10, 4.0f, 8.0f, ProjectileHitPlayer);
    }

    private void ProjectileHitPlayer(Hurtbox _player, Projectile _projectile)
    {
        Destroy(_projectile.gameObject);

        _player.ApplyDamage(_projectile.m_damage);

        //HealthComponent healthComp = _player.GetComponent<HealthComponent>();
        //healthComp.Health -= _projectile.m_damage;
    }

    private void OnHurt()
    {
        AudioManager.Instance.PlaySound("hitBoss");
        ScreenshakeManager.Shake(ScreenshakeManager.EShakeType.small);

        float newFillAmount = Mathf.Clamp01(m_healthComp.Health / m_healthComp.MaxHealth);
        m_healthBar.FillAmount = newFillAmount;

        m_animator.SetTrigger("Damaged");
        // m_healthBar.fillAmount = newFillAmount;

        // DOTween.Kill(this);
        // DOTween.To(() => m_healthBarChase.fillAmount, x => m_healthBarChase.fillAmount = x, newFillAmount, 0.2f).SetEase(Ease.OutQuad);
    }

    private void OnDeath()
    {
        m_state = EState.idle;

        m_animator.SetTrigger("Death");
        AudioManager.Instance.PlaySound("bossDeath");

        foreach(Player player in FindObjectsOfType<Player>())
        {
            player.WonGame();
        }

        StartCoroutine(Wait(4.0f, () =>
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("WinScene");
        }));
    }

    public void NextAttack()
    {
        EState nextState = (m_state == EState.wormholeAttack) ? EState.attacking : EState.rippingReality;

        m_state = EState.idle;

        StartCoroutine(Wait(1.0f, () =>
        {
            m_state = nextState;

            if (m_state == EState.attacking)
            {
                StartCoroutine(Wait(m_basicAttackLength, () =>
                {
                    NextAttack();
                }));
            }
        }));
    }

    public void ApplyDiamondEffectDebuff()
    {
        m_diamondDebuff = true;
        m_diamondDebuffDuration = m_kDiamondDebuffMaxDuration;
    }

    private void UpdateDebuff()
    {
        // use how much time has passed to calculate the scale and position of the duration indicator
        if (m_diamondDebuff)
        {
            m_diamondDebuffDuration -= Time.deltaTime;
            m_diamondEffectIndicator.enabled = true;
            m_diamondEffectDurationIndicator.enabled = true;
            m_spriteRenderer.color = m_diamondEffectColor;

            // set position of duration indicator
            Vector3 position = m_diamondEffectDurationIndicator.rectTransform.localPosition;
            position.y = 50f * (m_diamondDebuffDuration / m_kDiamondDebuffMaxDuration);
            m_diamondEffectDurationIndicator.rectTransform.localPosition = position;

            // set scale of duration indicator
            Vector3 scale = m_diamondEffectDurationIndicator.rectTransform.localScale;
            scale.y = (1f - (m_diamondDebuffDuration / m_kDiamondDebuffMaxDuration));
            m_diamondEffectDurationIndicator.rectTransform.localScale = scale;

            if (m_diamondDebuffDuration <= 0)
            {
                m_diamondDebuff = false;
                m_diamondEffectIndicator.enabled = false;
                m_diamondEffectDurationIndicator.enabled = false;
                m_spriteRenderer.color = Color.white;
            }
        }
    }
}
