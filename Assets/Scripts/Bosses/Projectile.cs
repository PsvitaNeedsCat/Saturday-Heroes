using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [HideInInspector] public int m_damage = 1;

    private float m_speed = 1.0f;
    private Rigidbody m_rigidBody = null;

    private Action<Hurtbox, Projectile> m_onHit = null;
    private EDamageType[] m_hitTypes = null;

    private void Awake()
    {
        m_rigidBody = GetComponent<Rigidbody>();
    }

    // Initialises the projectile
    public void Init(
        EDamageType[] _hitTypes,
        int _damage = 1, 
        float _speed = 1.0f, 
        float _timeUntilDestroy = 3.0f, 
        Action<Hurtbox, Projectile> _onHit = null )
    {
        m_hitTypes = _hitTypes;

        m_damage = _damage;

        m_speed = _speed;

        if (_timeUntilDestroy > 0.0f)
        {
            Destroy(gameObject, _timeUntilDestroy);
        }

        m_onHit = _onHit;

        m_rigidBody.velocity = transform.forward * m_speed;
    }

    // Checks if the collision was with something valid
    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < m_hitTypes.Length; i++)
        {
            // Component comp = other.GetComponent(m_hitTypes[i]);
            Hurtbox hurtbox = other.GetComponent<Hurtbox>();
            if (hurtbox && (hurtbox.m_damageType == m_hitTypes[i]))
            {
                m_onHit?.Invoke(hurtbox, this);
                return;
            }
        }
    }

    public void ChangeDirection(Vector3 _direction)
    {
        m_rigidBody.velocity = Vector3.zero;

        transform.rotation = Quaternion.LookRotation(_direction);

        m_rigidBody.velocity = transform.forward * m_speed;
    }
}
