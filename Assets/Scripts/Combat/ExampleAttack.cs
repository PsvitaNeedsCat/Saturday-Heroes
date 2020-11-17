using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleAttack : MonoBehaviour, IHitboxListener
{
    public int m_damage = 1;
    public Hitbox m_hitbox;
    public float m_attackDuration = 0.5f;
    public Animator m_animator;

    private bool m_hitboxActive;
    private int m_attackIndex = 0;

    public void Attack()
    {
        // Wait for attack to finish
        if (m_hitboxActive)
        {
            return;
        }

        m_animator.SetTrigger("Attack");
        m_animator.SetInteger("AttackIndex", m_attackIndex);
        m_attackIndex = (m_attackIndex == 0) ? 1 : 0;

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
    }

    public void CollidedWith(Collider _collider)
    {
        Parryable parryable = _collider.GetComponent<Parryable>();
        if (parryable)
        {
            Debug.Log("Parried object, gained: " + parryable.m_manaValue);
            parryable.OnParried();
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
