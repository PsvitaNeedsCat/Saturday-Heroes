using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    private float m_speed = 1.0f;
    private Rigidbody m_rigidBody = null;

    private Action m_onHit = null;
    private Type[] m_hitTypes = null;

    private void Awake()
    {
        m_rigidBody = GetComponent<Rigidbody>();
    }

    // Initialises the projectile
    public void Init(Action _onHit, Type[] _hitTypes, float _speed = 1.0f)
    {
        m_speed = _speed;

        m_onHit = _onHit;

        m_hitTypes = _hitTypes;
    }

    // Checks if the collision was with something valid
    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < m_hitTypes.Length; i++)
        {
            Component comp = other.GetComponent(m_hitTypes[i]);
            if (comp)
            {
                m_onHit?.Invoke();
                return;
            }
        }
    }

    private void FixedUpdate()
    {
        m_rigidBody.AddForce(transform.forward * m_speed, ForceMode.Impulse);
    }
}
