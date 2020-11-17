using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatInput : MonoBehaviour
{
    private CheatConsole m_cheatConsole = null;
    private MasterControls m_controls;

    private void Awake()
    {
        m_cheatConsole = GetComponent<CheatConsole>();

        m_controls = new MasterControls();

        // Toggle
        m_controls.Console.ToggleConsole.performed += _ => m_cheatConsole.OnToggleDebug();

        // Handle input
        m_controls.Console.HandleInput.performed += _ => m_cheatConsole.OnReturn();

        // Switch commands
        m_controls.Console.SwitchCommands.performed += ctx => HandleArrowKeys(ctx.ReadValue<float>());

        m_controls.Console.Enable();
    }

    private void HandleArrowKeys(float _value)
    {
        if (_value < 0.0f)
        {
            m_cheatConsole.NextEntry();
        }
        else
        {
            m_cheatConsole.PreviousEntry();
        }
    }
}
