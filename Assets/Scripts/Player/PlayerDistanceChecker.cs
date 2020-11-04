using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDistanceChecker : MonoBehaviour
{
    [HideInInspector] public bool m_withinRadius = false;

    private Player[] m_players;

    private const float m_kRadius = 6.0f;

    private void Start()
    {
        m_players = FindObjectsOfType<Player>();
    }

    private void Update()
    {
        MoveBetweenPlayers();

        CheckPlayerDistance();
    }

    private void MoveBetweenPlayers()
    {
        Vector3 playerToPlayer = m_players[0].transform.position - m_players[1].transform.position;

        transform.position = m_players[1].transform.position + (playerToPlayer * 0.5f);
    }

    private void CheckPlayerDistance()
    {
        Vector3 playerToPlayer = m_players[0].transform.position - m_players[1].transform.position;

        m_withinRadius = playerToPlayer.magnitude <= m_kRadius * 2.0f;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = (m_withinRadius) ? Color.green : Color.red;

        Gizmos.DrawWireSphere(transform.position, m_kRadius);
    }
}
