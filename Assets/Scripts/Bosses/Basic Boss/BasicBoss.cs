using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BasicBoss : MonoBehaviour
{
    public Image m_healthBar;
    public Image m_healthBarChase;

    private enum EState
    {
        init,
        idle,
        attacking,
    };
    private EState m_state = EState.init;

    [Header("Basic Attack")]
    private float m_fireRate = 1.0f;
    private float m_firingTimer = 0.0f;
    private EDamageType[] m_projHitTypes =
    {
        EDamageType.player,
    };
    private GameObject m_projectilePrefab = null;
    [SerializeField] private Transform[] m_projectileSpawns = new Transform[] { };

    [Header("Components")]
    private HealthComponent m_healthComp;

    private void Awake()
    {
        m_projectilePrefab = Resources.Load<GameObject>("prefabs/Bosses/Basic Boss/BossProjectile");

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

            default:
                {
                    break;
                }
        }
    }

    // Called every frame the boss is in init state
    private void InitState()
    {
        StartCoroutine(Roar());

        m_state = EState.idle;
    }

    // Plays a roar clip and waits for it to be over before changing states
    private IEnumerator Roar()
    {
        AudioManager.Instance.PlaySound("roar");

        yield return new WaitForSeconds(2.8f);

        m_state = EState.attacking;
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

        float newFillAmount = Mathf.Clamp01(m_healthComp.Health / m_healthComp.MaxHealth);
        m_healthBar.fillAmount = newFillAmount;

        DOTween.Kill(this);
        DOTween.To(() => m_healthBarChase.fillAmount, x => m_healthBarChase.fillAmount = x, newFillAmount, 0.2f).SetEase(Ease.OutQuad);
    }
}
