﻿using System.Collections;
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

        m_controls.devices = new[] { Gamepad.all[m_playerNumber] };

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

        m_controls.Player.Enable();
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
}
