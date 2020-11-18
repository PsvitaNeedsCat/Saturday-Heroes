using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BasicBoss : MonoBehaviour
{
    public UIBar m_healthBar;
    public Image m_healthBarChase;
    

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
    private HealthComponent m_healthComp;

    private void Awake()
    {
        m_projectilePrefab = Resources.Load<GameObject>("Prefabs/Bosses/Basic Boss/BossProjectile");

        m_wormholePrefab = Resources.Load<GameObject>("Prefabs/Bosses/Basic Boss/Wormhole");
        m_wormholeProjectilePrefab = Resources.Load<GameObject>("Prefabs/Bosses/Basic Boss/WormholeProjectile");

        m_healthComp = GetComponent<HealthComponent>();
        m_healthComp.Init(10, OnHurt);
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

    private IEnumerator Wait(float _seconds, System.Action _action)
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
        m_firingTimer += Time.deltaTime;

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
        // m_healthBar.fillAmount = newFillAmount;

        // DOTween.Kill(this);
        // DOTween.To(() => m_healthBarChase.fillAmount, x => m_healthBarChase.fillAmount = x, newFillAmount, 0.2f).SetEase(Ease.OutQuad);
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
}
