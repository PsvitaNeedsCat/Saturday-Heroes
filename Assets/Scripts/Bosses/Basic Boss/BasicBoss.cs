﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBoss : MonoBehaviour
{
    private enum EState
    {
        idle,
        attacking,
    };
    private EState m_state = EState.idle;

    private float m_fireRate = 1.0f;
    private float m_firingTimer = 0.0f;

    private GameObject m_projectilePrefab = null;
    private System.Type[] m_projHitTypes =
    {
        typeof(Player),
    };

    private void Awake()
    {
        m_projectilePrefab = Resources.Load<GameObject>("prefabs/Bosses/Basic Boss/BossProjectile");

        HealthComponent healthComp = GetComponent<HealthComponent>();
        healthComp.Init(10);
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

        proj.Init(m_projHitTypes, 1, 0.1f, 3.0f, ProjectileHitPlayer);
    }

    private void ProjectileHitPlayer(Collider _player, Projectile _projectile)
    {
        Destroy(_projectile.gameObject);

        HealthComponent healthComp = _player.GetComponent<HealthComponent>();
        healthComp.Health -= _projectile.m_damage;
    }
}
