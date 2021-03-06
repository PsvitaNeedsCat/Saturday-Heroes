﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector] public Vector2 m_moveDirection = Vector2.zero;

    [SerializeField] private FillBar m_reviveBar = null;

    private Player m_otherPlayer = null;
    private Rigidbody m_rigidbody = null;
    private HealthComponent m_health = null;
    private ManaComponent m_mana = null;
    private PlayerInput m_playerInput = null;
    [HideInInspector] public int m_playerNumber;
    public ESuit m_playerSuit;
    private bool m_attemptingRevive = false;
    private List<ECard> m_cardPool = null;
    
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

    [HideInInspector] public int m_comboMultiplier = 1;
    private int m_currentCombo = 0;

    private bool m_heartEffect = false;
    private int m_heartEffectTriggers = 0;

    private bool m_diamondEffect = false;
    private int m_diamondEffectTriggers = 0;

    public int CurrentCombo    {        get        {            return m_currentCombo;        }        set        {            m_currentCombo = value;            int m_oldMultiplier = m_comboMultiplier;            if (m_currentCombo < 2)            {                m_comboMultiplier = 1;            }            else if (m_currentCombo >= 2 && m_currentCombo < 4)            {                m_comboMultiplier = 2;            }            else            {                m_comboMultiplier = 4;            }            // If combo multiplier changed, update UI            if (m_comboMultiplier != m_oldMultiplier)            {                UIManager.Instance.UpdatePlayerCombo(m_playerNumber, m_comboMultiplier);                if (m_comboMultiplier > m_oldMultiplier)
                {
                    AudioManager.Instance.PlaySound("comboLevelUp");
                }                else
                {
                    AudioManager.Instance.PlaySound("comboLost");
                }            }        }    }

    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_playerInput = GetComponent<PlayerInput>();
        m_health = GetComponent<HealthComponent>();
        m_health.Init(100, OnHurt, Downed, OnHealed);        m_mana = GetComponent<ManaComponent>();        m_mana.Init(GenerateNewCard, ManaUpdated, ManaUpdated);
        m_cardPool = new List<ECard>();        foreach (ECard card in CardManager.m_kCardSuits.Keys)        {            if (card == ECard.None)            {                continue;            }            if (CardManager.m_kCardSuits[card] == m_playerSuit || CardManager.m_kCardSuits[card] == ESuit.None)            {                m_cardPool.Add(card);            }        }
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

    private void Update()
    {
        m_mana.Mana += (3f + (m_heartEffect ? 3f : 0f)) * Time.deltaTime * m_comboMultiplier;
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

            Vector3 moveVector = m_moveForce * moveDirection.normalized * Time.fixedDeltaTime * (m_diamondEffect ? 1.25f : 1.0f);
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
        CurrentCombo = 0;
    }

    private void OnHealed()
    {

    }

    private void Downed()
    {
        m_health.m_isDead = true;

        m_playerInput.SetControls(false);

        m_animator.SetBool("Downed", true);
        AudioManager.Instance.PlaySound("playerDeath");

        if (m_otherPlayer.m_health.m_isDead)
        {
            StartCoroutine(LostGame());
        }
    }

    private void Revived()
    {
        m_health.m_isDead = false;
        m_health.Health = m_health.MaxHealth;
        m_health.SetIFramesTimer(3.0f);
        AudioManager.Instance.PlaySound("revive");

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
    
    public bool AttemptPlaceCard(CardData _card)    {        if (_card.ID == ECard.None)
        {
            return false;
        }

        // find the tile that is below the player
        Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 10f, LayerMask.GetMask("GridTile"));        if (hit.transform == null)        {            return false;        }

        // if that tile already has a card above it...
        Physics.Raycast(hit.transform.position, Vector3.up, out RaycastHit cardHit, 10f, LayerMask.GetMask("Card"));        if (cardHit.transform)        {
            // report failure to place a new card false
            return false;        }

        // otherwise instantiate the new card right above the tile
        Instantiate(_card.GetPrefab(), hit.transform.position + Vector3.up * 0.1f, Quaternion.identity);        CardManager.UseSelectedCard(m_playerNumber);        m_animator.SetTrigger("PlaceCard");        return true;
    }
    private void ManaUpdated()    {        UIManager.Instance.UpdatePlayerManaBar(m_playerNumber, m_mana.Mana, m_mana.MaxMana);    }
    private void GenerateNewCard()    {        // pick a random card        CardManager.GiveCard(m_playerNumber, m_cardPool[Random.Range(0, m_cardPool.Count)]);        AudioManager.Instance.PlaySound("drawCard");        UIManager.Instance.OnCardDrawn(m_playerNumber);    }

    private IEnumerator LostGame()
    {
        yield return new WaitForSeconds(1.0f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("LoseScene");
    }

    public void WonGame()
    {
        m_animator.SetTrigger("Victory");
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("CardEffect"))
        {
            ECard card = other.GetComponentInParent<Card>().GetCardID();

            if (card == ECard.DiamondEffect)
            {
                m_diamondEffectTriggers++;
                m_diamondEffect = true;
            }
            else if (card == ECard.HeartEffect)
            {
                m_heartEffectTriggers++;
                m_heartEffect = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("CardEffect"))
        {
            ECard card = other.GetComponentInParent<Card>().GetCardID();

            if (card == ECard.DiamondEffect)
            {
                m_diamondEffectTriggers--;
                if (m_diamondEffectTriggers == 0)
                {
                    m_diamondEffect = false;
                }
            }
            else if (card == ECard.HeartEffect)
            {
                m_heartEffectTriggers--;
                if (m_heartEffectTriggers == 0)
                {
                    m_heartEffect = false;
                }
            }
        }
    }
}
