using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector] public Vector2 m_moveDirection = Vector2.zero;

    private Rigidbody m_rigidbody = null;
    private PlayerDistanceChecker m_distanceChecker = null;

    public Transform m_rotatable;
    public Animator m_animator;

    [Header("Movement")]

    public float m_moveForce;
    public float m_maxSpeed;

    public float m_brakingDrag = 0.9f; // Used when no directional input
    public float m_movingDrag = 0.5f;
    public float m_dragCoefficient = 10.0f;
    private float m_currentDrag = 0.9f;

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
        // If no directional input, the player is 'braking'
        bool playerBraking = (m_moveDirection.magnitude < 0.01f);

        Vector3 playerVelocity = m_rigidbody.velocity;
        playerVelocity.y = 0.0f;

        m_animator.SetFloat("XSpeed", playerVelocity.normalized.x);
        m_animator.SetFloat("ZSpeed", playerVelocity.normalized.z);

        float playerHorSpeed = playerVelocity.magnitude;

        // Only apply move speed if under max speed, and there is directional input
        if ((playerHorSpeed < m_maxSpeed) && !playerBraking)
        {
            Vector3 moveDirection = Camera.main.RelativeDirection(m_moveDirection);
            m_rotatable.transform.forward = moveDirection;

            Vector3 moveVector = m_moveForce * moveDirection.normalized * Time.fixedDeltaTime;
            m_rigidbody.AddForce(moveVector, ForceMode.Impulse);
        }

        ApplyDrag(playerBraking);
    }

    private void ApplyDrag(bool _braking)
    {
        m_currentDrag = (_braking) ? m_brakingDrag : m_movingDrag;

        Vector3 playerVelocity = m_rigidbody.velocity;
        playerVelocity.y = 0.0f;

        m_rigidbody.AddForce(-playerVelocity * m_currentDrag * m_dragCoefficient * Time.fixedDeltaTime, ForceMode.Impulse);
    }
}
