using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaComponent : MonoBehaviour
{
    private float m_mana = 0.0f;
    private float m_maxMana = 100.0f;

    private System.Action m_onGenerateCard = null;
    private System.Action m_onGainedMana = null;
    private System.Action m_onLostMana = null;

    public float Mana
    {
        get
        {
            return m_mana;
        }
        set
        {
            float delta = value - m_mana;

            m_mana = value;

            if (m_mana >= m_maxMana)
            {
                m_mana -= m_maxMana;

                m_onGenerateCard?.Invoke();
            }

            m_mana = Mathf.Clamp(m_mana, 0.0f, m_maxMana);

            if (delta < 0.0f)
            {
                m_onLostMana?.Invoke();
            }
            else if (delta > 0.0f)
            {
                m_onGainedMana?.Invoke();
            }
        }
    }

    public float MaxMana
    {
        get
        {
            return m_maxMana;
        }
        set
        {
            m_maxMana = value;
        }
    }

    public void Init(
        System.Action _onGenerateCard, 
        System.Action _onGainedMana, 
        System.Action _onLostMana, 
        float _maxMana = 100.0f, 
        float _currentMana = 0.0f)
    {
        m_onGenerateCard = _onGenerateCard;
        m_onGainedMana = _onGainedMana;
        m_onLostMana = _onLostMana;

        m_maxMana = _maxMana;
        m_mana = _currentMana;
    }
}
