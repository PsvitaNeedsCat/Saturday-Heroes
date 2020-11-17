using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image[] m_playerHealthBars = new Image[2];

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
        m_playerHealthBars[_playerNum].fillAmount = (_health == 0.0f) ? 0.0f : _health / _maxHealth;
    }
}
