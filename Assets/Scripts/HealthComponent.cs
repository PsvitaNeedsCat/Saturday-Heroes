using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HealthComponent : MonoBehaviour
{
    [HideInInspector] public bool m_isDead = false;
    public Renderer m_hitFlashRenderer;

    private float m_health = 3.0f;
    private float m_maxHealth = 3.0f;
    private bool m_isInvincible = false;
    private float m_invincibleTimer = 0.0f;

    private System.Action m_OnHurt;
    private System.Action m_OnHealed;
    private System.Action m_OnDeath;

    public float Health
    {
        get
        {
            return m_health;
        }
        set
        {
            if (m_isDead)
            {
                return;
            }

            float delta = value - m_health;
            
            if (delta < 0 && m_isInvincible)
            {
                return;
            }

            // Set health
            m_health = Mathf.Clamp(value, 0, m_maxHealth);

            // Call functions
            if (delta < 0.0f)
            {
                m_OnHurt?.Invoke();
                DOTween.Kill(this);
                DOTween.To(() => m_hitFlashRenderer.material.GetFloat("_FlashAmount"), x => m_hitFlashRenderer.material.SetFloat("_FlashAmount", x), 1.0f, 0.1f).OnComplete(() =>
                {
                    DOTween.To(() => m_hitFlashRenderer.material.GetFloat("_FlashAmount"), x => m_hitFlashRenderer.material.SetFloat("_FlashAmount", x), 0.0f, 0.2f);
                });
            }
            if (m_health == 0.0f)
            {
                m_OnDeath?.Invoke();
            }
            if (delta > 0.0f)
            {
                m_OnHealed?.Invoke();
            }
        }
    }

    public float MaxHealth
    {
        get
        {
            return m_maxHealth;
        }
        set
        {
            if (value <= 0.0f)
            {
                return;
            }

            m_maxHealth = value;
            m_health = m_maxHealth;
        }
    }

    // Initialises the health component
    public void Init(float _health, System.Action _onHurt = null, System.Action _onDeath = null, System.Action _onHealed = null)
    {
        // Set health
        m_health = _health;
        m_maxHealth = _health;

        // Set actions
        m_OnHurt = _onHurt;
        m_OnDeath = _onDeath;
        m_OnHealed = _onHealed;
    }

    public void SetIFramesTimer(float _timer)
    {
        m_invincibleTimer = _timer;

        m_isInvincible = _timer > 0.0f;
    }

    private void Update()
    {
        if (m_isInvincible)
        {
            m_invincibleTimer -= Time.deltaTime;
            if (m_invincibleTimer <= 0.0f)
            {
                m_isInvincible = false;
            }
        }
    }

    // Kills even if invincible
    public void ForceKill()
    {
        m_health = 0.0f;

        m_OnDeath();
    }
}
