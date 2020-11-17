using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector] public Vector2 m_moveDirection = Vector2.zero;

    [SerializeField] private FillBar m_reviveBar = null;

    private Player m_otherPlayer = null;
    private Rigidbody m_rigidbody = null;
    private HealthComponent m_health = null;
    private PlayerInput m_playerInput = null;
    [HideInInspector] public int m_playerNumber;
    private bool m_attemptingRevive = false;
    
    // Reviving
    private const float m_kReviveRadius = 1.0f;
    private const float m_kTimeToRevive = 1.5f;
    private float m_revivingTimer = 0.0f;

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

        m_playerInput = GetComponent<PlayerInput>();

        m_health = GetComponent<HealthComponent>();
        m_health.Init(100, OnHurt, Downed, OnHealed);
    }

    private void Start()
    {
        Player[] players = FindObjectsOfType<Player>();
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].m_playerNumber != m_playerNumber)
            {
                m_otherPlayer = players[i];
                break;
            }
        }
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

        m_animator.SetFloat("Speed", playerVelocity.z);

        float playerHorSpeed = playerVelocity.magnitude;

        // Only apply move speed if under max speed, and there is directional input
        if ((playerHorSpeed < m_maxSpeed) && !playerBraking)
        {
            Vector3 moveDirection = Camera.main.RelativeDirection(m_moveDirection);
            //m_rotatable.transform.forward = moveDirection;

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
        ScreenshakeManager.Shake(ScreenshakeManager.EShakeType.shortSharp);

        UIManager.Instance.UpdatePlayerHealthBar(m_playerNumber, m_health.Health, m_health.MaxHealth);
    }

    private void OnHealed()
    {

    }

    private void Downed()
    {
        m_health.m_isDead = true;

        m_playerInput.SetControls(false);

        m_animator.SetBool("Downed", true);
    }

    private void Revived()
    {
        m_health.m_isDead = false;
        m_health.Health = m_health.MaxHealth;
        m_health.SetIFramesTimer(3.0f);

        UIManager.Instance.UpdatePlayerHealthBar(m_playerNumber, m_health.Health, m_health.MaxHealth);

        m_playerInput.SetControls(true);

        m_animator.SetBool("Downed", false);
    }

    public IEnumerator TryRevive()
    {
        m_revivingTimer = m_kTimeToRevive;
        m_attemptingRevive = true;

        while (m_attemptingRevive)
        {
            if (!m_otherPlayer.m_health.m_isDead)
            {
                StopReviving();
                break;
            }

            float playerDistance = (m_otherPlayer.transform.position - transform.position).magnitude;

            if (playerDistance <= m_kReviveRadius)
            {
                m_revivingTimer -= Time.deltaTime;
            }
            else
            {
                m_revivingTimer = m_kTimeToRevive;
            }

            m_revivingTimer = Mathf.Clamp(m_revivingTimer, 0.0f, m_kTimeToRevive);
            
            UpdateReviveIcon();

            if (m_revivingTimer <= 0.0f)
            {
                // Revived!
                m_otherPlayer.Revived();
            }

            yield return null;
        }
    }

    public void StopReviving()
    {
        if (!m_attemptingRevive)
        {
            return;
        }

        m_attemptingRevive = false;

        m_revivingTimer = m_kTimeToRevive;
        
        UpdateReviveIcon();
    }

    private void UpdateReviveIcon()
    {
        bool withinRadius = (m_otherPlayer.transform.position - transform.position).magnitude <= m_kReviveRadius;
        bool isBarActive = m_revivingTimer > 0.0f && m_attemptingRevive && withinRadius;

        m_reviveBar.transform.parent.parent.gameObject.SetActive(isBarActive);
        m_reviveBar.FillAmount = (isBarActive) ? 1.0f - (m_revivingTimer / m_kTimeToRevive) : 0.0f;
    }
    
    public bool AttemptPlaceCard(CardManager.CardData _card)
    {
        // find the tile that is below the player
        Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 10f, LayerMask.GetMask("GridTile"));

        if (hit.transform == null)
        {
            return false;
        }

        // if that tile already has a card above it...
        Physics.Raycast(hit.transform.position, Vector3.up, out RaycastHit cardHit, 10f, LayerMask.GetMask("Card"));
        if (cardHit.transform)
        {
            // report failure to place a new card false
            return false;
        }

        // otherwise instantiate the new card right above the tile
        Instantiate(_card.GetPrefab(), hit.transform.position + Vector3.up * 0.1f, Quaternion.identity);
        CardManager.UseSelectedCard(m_playerNumber);
        return true;
    }
}
