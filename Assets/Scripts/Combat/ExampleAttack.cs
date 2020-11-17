using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleAttack : MonoBehaviour, IHitboxListener
{
    public int m_damage = 1;
    public Hitbox m_hitbox;
    public float m_attackDuration = 0.5f;
    public float m_attackCooldown= 0.5f;
    public Animator m_animator;

    private bool m_hitboxActive;
    private int m_attackIndex = 0;
    private float m_cooldownTimer = 0.0f;

    private ManaComponent m_mana = null;

    private void Awake()
    {
        m_mana = GetComponent<ManaComponent>();
    }

    

    public void Attack()
    {
        // Wait for attack to finish
        if (m_hitboxActive || m_cooldownTimer > 0.0f)
        {
            return;
        }

        m_animator.SetTrigger("Attack");
        m_animator.SetInteger("AttackIndex", m_attackIndex);
        AudioManager.Instance.PlaySound("swing");
        m_attackIndex = (m_attackIndex == 0) ? 1 : 0;
        m_cooldownTimer = m_attackCooldown;

        m_hitbox.SetListener(this);

        StopAllCoroutines();

        StartCoroutine(SetAttackCollider(m_attackDuration));
    }

    private IEnumerator SetAttackCollider(float _forSeconds)
    {
        SetHitbox(true);

        yield return new WaitForSeconds(_forSeconds);

        SetHitbox(false);
    }

    private void SetHitbox(bool _active)
    {
        m_hitboxActive = _active;

        if (m_hitboxActive)
        {
            m_hitbox.EnableCollisions();
        }
        else
        {
            m_hitbox.DisableCollisions();
        }
    }

    private void Update()
    {
        if (m_hitboxActive)
        {
            m_hitbox.HitboxUpdate();
        }
        else
        {
            m_cooldownTimer -= Time.deltaTime;
        }
    }

    public void CollidedWith(Collider _collider)
    {
        Parryable parryable = _collider.GetComponent<Parryable>();
        if (parryable)
        {
            parryable.OnParried();
            AudioManager.Instance.PlaySound("parry");
            EffectsManager.SpawnEffect("Parry", _collider.transform.position, Quaternion.Euler(-90.0f, 0.0f, 0.0f), Vector3.one, 2.0f);

            m_mana.Mana += parryable.m_manaValue;
        }

        Hurtbox hurtbox = _collider.GetComponent<Hurtbox>();
        if (hurtbox)
        {
            if (hurtbox.m_damageType != m_hitbox.m_damageType)
            {
                hurtbox.ApplyDamage(m_damage);
            }
        }
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 50, 20), "Attack"))
        {
            Attack();
        }
    }
}
