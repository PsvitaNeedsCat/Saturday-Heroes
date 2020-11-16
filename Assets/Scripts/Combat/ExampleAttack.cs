using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleAttack : MonoBehaviour, IHitboxListener
{
    public int m_damage = 1;
    public Hitbox m_hitbox;
    public float m_attackDuration = 0.5f;

    private bool m_hitboxActive;

    public void Attack()
    {
        // Wait for attack to finish
        if (m_hitboxActive)
        {
            return;
        }

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
