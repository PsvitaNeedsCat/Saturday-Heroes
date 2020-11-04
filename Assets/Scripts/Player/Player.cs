using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector] public Vector2 m_moveDirection = Vector2.zero;

    private Rigidbody m_rigidbody = null;

    // Const
    private const float m_kBaseSpeed = 1.0f;

    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 moveDirection = Camera.main.RelativeDirection(m_moveDirection);

        transform.forward = moveDirection;

        m_rigidbody.AddForce(moveDirection.normalized * m_kBaseSpeed, ForceMode.Impulse);
    }
}
