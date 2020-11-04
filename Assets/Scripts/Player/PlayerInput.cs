using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private int m_playerNumber = 0;

    private MasterControls m_controls;
    private Player m_player;

    private void Awake()
    {
        m_player = GetComponent<Player>();
        m_controls = new MasterControls();

        m_controls.devices = new[] { Gamepad.all[m_playerNumber] };

        m_controls.Player.Movement.performed += ctx => m_player.m_moveDirection = ctx.ReadValue<Vector2>();
        m_controls.Player.Movement.canceled += ctx => m_player.m_moveDirection = ctx.ReadValue<Vector2>();

        m_controls.Player.Enable();
    }
}
