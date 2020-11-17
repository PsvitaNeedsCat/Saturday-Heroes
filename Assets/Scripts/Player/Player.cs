using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector] public Vector2 m_moveDirection = Vector2.zero;

    private Rigidbody m_rigidbody = null;
    private HealthComponent m_health = null;
    [HideInInspector] public int m_playerNumber;

    [SerializeField] private Transform m_rotatable;
    [SerializeField] private Animator m_animator;

    [Header("Movement")]

    [SerializeField] private float m_moveForce;
    [SerializeField] private float m_maxSpeed;

    [SerializeField] private float m_brakingDrag = 0.9f; // Used when no directional input
    [SerializeField] private float m_movingDrag = 0.5f;
    [SerializeField] private float m_dragCoefficient = 10.0f;
    private float m_currentDrag = 0.9f;

    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();

        m_health = GetComponent<HealthComponent>();
        m_health.Init(100, OnHurt, Downed, OnHealed);
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

    private void OnHurt()
    {
        AudioManager.Instance.PlaySound("playerHurt");

        UIManager.Instance.UpdatePlayerHealthBar(m_playerNumber, m_health.Health, m_health.MaxHealth);
    }

    private void OnHealed()
    {

    }

    private void Downed()
    {

    }

    private void Revived()
    {

    }
}
