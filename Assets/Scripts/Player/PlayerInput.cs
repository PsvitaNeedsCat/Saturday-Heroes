using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private int m_playerNumber = 0;

    private MasterControls m_controls;
    private Player m_player;
    private ExampleAttack m_attack;

    private void Awake()
    {
        m_player = GetComponent<Player>();
        m_player.m_playerNumber = m_playerNumber;

        m_controls = new MasterControls();

        if (Gamepad.all.Count < m_playerNumber + 1)
        {
            Debug.Log("No gamepad available for player " + m_playerNumber);

            m_controls.devices = new[] { Keyboard.all[0] };
        }
        else
        {
            Debug.Log("Gamepad available for player " + m_playerNumber);

            m_controls.devices = new[] { Gamepad.all[m_playerNumber], Keyboard.all[0] };
        }

        // Movement
        m_controls.Player.Movement.performed += ctx => m_player.m_moveDirection = ctx.ReadValue<Vector2>();
        m_controls.Player.Movement.canceled += ctx => m_player.m_moveDirection = ctx.ReadValue<Vector2>();

        // Attack
        m_attack = GetComponent<ExampleAttack>();
        if (m_attack)
        {
            m_controls.Player.Attack.performed += _ => m_attack.Attack();
        }

        // Revive
        m_controls.Player.Revive.performed += _ => StartCoroutine(m_player.TryRevive());
        m_controls.Player.Revive.canceled += _ => m_player.StopReviving();

        // Card selection
        m_controls.Player.CardSelection.performed += ctx => ChangeCardSelection(ctx.ReadValue<float>());

        // Play card
        m_controls.Player.PlayCard.performed += _ => m_player.AttemptPlaceCard(CardManager.GetSelectedCard(m_playerNumber));

        // Keyboard
        if (m_playerNumber == 0)
        {
            // Movement
            m_controls.Player1Keyboard.Movement.performed += ctx => m_player.m_moveDirection = ctx.ReadValue<Vector2>();
            m_controls.Player1Keyboard.Movement.canceled += ctx => m_player.m_moveDirection = ctx.ReadValue<Vector2>();

            // Attack
            m_attack = GetComponent<ExampleAttack>();
            if (m_attack)
            {
                m_controls.Player1Keyboard.Attack.performed += _ => m_attack.Attack();
            }

            // Revive
            m_controls.Player1Keyboard.Revive.performed += _ => StartCoroutine(m_player.TryRevive());
            m_controls.Player1Keyboard.Revive.canceled += _ => m_player.StopReviving();

            // Card selection
            m_controls.Player1Keyboard.CardSelection.performed += ctx => ChangeCardSelection(ctx.ReadValue<float>());

            // Play card
            m_controls.Player1Keyboard.PlayCard.performed += _ => m_player.AttemptPlaceCard(CardManager.GetSelectedCard(m_playerNumber));

            m_controls.Player1Keyboard.Enable();
        }
        else // Player 2
        {
            // Movement
            m_controls.Player2Keyboard.Movement.performed += ctx => m_player.m_moveDirection = ctx.ReadValue<Vector2>();
            m_controls.Player2Keyboard.Movement.canceled += ctx => m_player.m_moveDirection = ctx.ReadValue<Vector2>();

            // Attack
            m_attack = GetComponent<ExampleAttack>();
            if (m_attack)
            {
                m_controls.Player2Keyboard.Attack.performed += _ => m_attack.Attack();
            }

            // Revive
            m_controls.Player2Keyboard.Revive.performed += _ => StartCoroutine(m_player.TryRevive());
            m_controls.Player2Keyboard.Revive.canceled += _ => m_player.StopReviving();

            // Card selection
            m_controls.Player2Keyboard.CardSelection.performed += ctx => ChangeCardSelection(ctx.ReadValue<float>());

            // Play card
            m_controls.Player2Keyboard.PlayCard.performed += _ => m_player.AttemptPlaceCard(CardManager.GetSelectedCard(m_playerNumber));

            m_controls.Player2Keyboard.Enable();
        }

        m_controls.Player.Enable();
    }

    private void OnDestroy()
    {
        m_controls.Disable();
    }

    public void SetControls(bool _active)
    {
        if (_active)
        {
            m_controls.Player.Enable();
            return;
        }

        m_controls.Player.Disable();
    }

    private void ChangeCardSelection(float _val)
    {
        if (_val > 0f)
        {
            CardManager.SelectNextCard(m_playerNumber);
        }
        else
        {
            CardManager.SelectPreviousCard(m_playerNumber);
        }
        AudioManager.Instance.PlaySound("rotateCards");
    }
}
