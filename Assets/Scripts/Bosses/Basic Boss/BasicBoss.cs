using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicBoss : MonoBehaviour
{
    public Image m_healthBar;

    private enum EState
    {
        idle,
        attacking,
    };
    private EState m_state = EState.idle;

    private float m_fireRate = 1.0f;
    private float m_firingTimer = 0.0f;

    private GameObject m_projectilePrefab = null;
    private HealthComponent m_healthComp;

    private EDamageType[] m_projHitTypes =
    {
        EDamageType.player,
    };

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
            case EState.idle:
                {
                    Idle();
                    break;
                }

            case EState.attacking:
                {
                    Attacking();
                    break;
                }

            default:
                {
                    break;
                }
        }
    }

    // Called every frame the boss is idle
    private void Idle()
    {
        m_state = EState.attacking;
    }

    // Called every frame the boss is attacking
    private void Attacking()
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
        Projectile proj = Instantiate(m_projectilePrefab, transform.position, rotation).GetComponent<Projectile>();

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

        m_healthBar.fillAmount = Mathf.Clamp01(m_healthComp.Health / m_healthComp.MaxHealth);
    }
}
