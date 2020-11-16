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

    private Action<Collider, Projectile> m_onHit = null;
    private Type[] m_hitTypes = null;

    private void Awake()
    {
        m_rigidBody = GetComponent<Rigidbody>();
    }

    // Initialises the projectile
    public void Init(
        Type[] _hitTypes, 
        int _damage = 1, 
        float _speed = 1.0f, 
        float _timeUntilDestroy = 3.0f, 
        Action<Collider, Projectile> _onHit = null )
    {
        m_hitTypes = _hitTypes;

        m_damage = _damage;

        m_speed = _speed;

        Destroy(gameObject, _timeUntilDestroy);

        m_onHit = _onHit;
    }

    // Checks if the collision was with something valid
    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < m_hitTypes.Length; i++)
        {
            Component comp = other.GetComponent(m_hitTypes[i]);
            if (comp)
            {
                m_onHit?.Invoke(other, this);
                return;
            }
        }
    }

    private void FixedUpdate()
    {
        m_rigidBody.AddForce(transform.forward * m_speed, ForceMode.Impulse);
    }
}
