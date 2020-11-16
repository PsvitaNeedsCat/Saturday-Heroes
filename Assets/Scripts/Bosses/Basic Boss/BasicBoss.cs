using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBoss : MonoBehaviour
{
    private enum EState
    {
        idle,
        attacking,
    };
    private EState m_state = EState.idle;

    private float m_fireRate = 1.0f;

    private void Update()
    {
        switch (m_state)
        {
            case EState.idle:
                {
                    Idle();
                    break;
                }

            case EState.attacking:
                {
                    Attacking();
                    break;
                }

            default:
                {
                    break;
                }
        }
    }

    // Called every frame the boss is idle
    private void Idle()
    {
        m_state = EState.attacking;
    }

    // Called every frame the boss is attacking
    private void Attacking()
    {

    }
}
