using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private UIBar[] m_playerHealthBars = new UIBar[2];
    [SerializeField] private UIBar[] m_playerManaBars = new UIBar[2];

    private static UIManager s_instance;
    public static UIManager Instance
    {
        get
        {
            return s_instance;
        }
    }

    private void Awake()
    {
        if (s_instance != null && s_instance != this)
        {
            Destroy(this);
            return;
        }
        s_instance = this;
    }

    public void UpdatePlayerHealthBar(int _playerNum, float _health, float _maxHealth)
    {
        m_playerHealthBars[_playerNum].FillAmount = (_health == 0.0f) ? 0.0f : _health / _maxHealth;
    }

    public void UpdatePlayerManaBar(int _playerNum, float _mana, float _maxMana)
    {
        m_playerManaBars[_playerNum].FillAmount = (_mana == 0.0f) ? 0.0f : _mana / _maxMana;
    }

    public void SwitchRight(int _player)
    {
        CardManager.SelectNextCard(_player);
    }

    public void SwitchLeft(int _player)
    {
        CardManager.SelectPreviousCard(_player);
    }

    public void PlaceCard(int _player)
    {
        foreach(Player player in FindObjectsOfType<Player>())
        {
            if (player.m_playerNumber == _player)
            {
                player.AttemptPlaceCard(CardManager.GetSelectedCard(_player));
            }
        }
    }
}
