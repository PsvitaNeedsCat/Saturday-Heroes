using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector] public Vector2 m_moveDirection = Vector2.zero;

    private Rigidbody m_rigidbody = null;
    private PlayerDistanceChecker m_distanceChecker = null;
    private float m_speed = 0.0f;

    // Const
    private const float m_kBaseSpeed = 1.0f;
    private const float m_kRadiusSpeed = 1.8f;

    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_distanceChecker = FindObjectOfType<PlayerDistanceChecker>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (m_moveDirection == Vector2.zero)
        {
            return;
        }

        if (m_distanceChecker)
        {
            m_speed = (m_distanceChecker.m_withinRadius) ? m_kRadiusSpeed : m_kBaseSpeed;
        }
        else
        {
            m_speed = m_kBaseSpeed;
        }

        Vector3 moveDirection = Camera.main.RelativeDirection(m_moveDirection);

        transform.forward = moveDirection;

        m_rigidbody.AddForce(moveDirection.normalized * m_speed, ForceMode.Impulse);
    }
}
