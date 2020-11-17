using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : CombatVolume
{
    public EColliderShape m_shape;
    public HealthComponent m_healthComp;

    private Collider m_collider;
    private EColliderState m_colliderState;
    private static Color[] m_colliderStateColors = { Color.grey, Color.green, Color.red };

    private void Awake()
    {
        m_collider = GetComponent<Collider>();
    }

    public void ApplyDamage(float _amount)
    {
        // Debug.Log("Hurtbox took " + _amount + " damage");
        if (m_healthComp)
        {
            m_healthComp.Health -= _amount;
        }
    }

    private void OnDrawGizmos()
    {
#if UNITY_EDITOR
        m_collider = GetComponent<Collider>();
#endif

        Color fadedColor = m_colliderStateColors[(int)m_colliderState];
        fadedColor.a = 0.3f;
        Gizmos.color = fadedColor;

        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale);

        if (m_shape == EColliderShape.cube)
        {
            BoxCollider boxCollider = m_collider as BoxCollider;
            Vector3 boxExtents = boxCollider.size;
            Gizmos.DrawCube(Vector3.zero, new Vector3(boxExtents.x, boxExtents.y, boxExtents.z));
        }
        else if (m_shape == EColliderShape.capsule)
        {
            CapsuleCollider capsuleCollider = m_collider as CapsuleCollider;
            float radius = capsuleCollider.radius;
            float halfHeight = capsuleCollider.height / 2.0f;
            Gizmos.DrawSphere(Vector3.zero + Vector3.up * (halfHeight - radius), radius);
            Gizmos.DrawSphere(Vector3.zero + Vector3.down * (halfHeight - radius), radius);
        }
        // Sphere for now
        else
        {
            SphereCollider sphereCollider = m_collider as SphereCollider;
            Gizmos.DrawSphere(Vector3.zero, sphereCollider.radius);
        }

    }
}
