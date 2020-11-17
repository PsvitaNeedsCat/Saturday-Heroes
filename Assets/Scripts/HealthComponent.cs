using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    private int m_health = 3;
    private int m_maxHealth = 3;
    private bool m_isInvincible = false;

    private System.Action m_OnHurt;
    private System.Action m_OnHealed;
    private System.Action m_OnDeath;

    public int Health
    {
        get
        {
            return m_health;
        }
        set
        {
            int delta = value - m_health;
            
            if (delta < 0 && m_isInvincible)
            {
                return;
            }

            // Set health
            m_health = Mathf.Clamp(value, 0, m_maxHealth);

            // Call functions
            if (delta < 0)
            {
                m_OnHurt?.Invoke();
            }
            if (m_health == 0)
            {
                m_OnDeath?.Invoke();
            }
            if (delta > 0)
            {
                m_OnHealed?.Invoke();
            }
        }
    }

    // Initialises the health component
    public void Init(int _health, System.Action _onHurt = null, System.Action _onDeath = null, System.Action _onHealed = null)
    {
        // Set health
        m_health = _health;
        m_maxHealth = _health;

        // Set actions
        m_OnHurt = _onHurt;
        m_OnDeath = _onDeath;
        m_OnHealed = _onHealed;
    }
}
