using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : CombatVolume
{
    public EColliderShape m_shape;
    public LayerMask m_hitLayers;

    public Vector3 m_cubeHalfExtents;
    public float m_sphereRadius;

    private IHitboxListener m_hitboxListener = null;
    private EColliderState m_colliderState;
    private static Color[] m_colliderStateColors = { Color.grey, Color.green, Color.red };
    private List<int> m_objectsHit = new List<int>();

    public void ToggleHitbox()
    {
        m_colliderState = (m_colliderState == EColliderState.open) ? EColliderState.closed : EColliderState.open;
    }

    private Collider[] OverlapCollider()
    {
        Collider[] colliders;

        if (m_shape == EColliderShape.cube)
        {
            colliders = Physics.OverlapBox(transform.position, m_cubeHalfExtents, transform.rotation, m_hitLayers);
        }
        // Sphere for now
        else
        {
            colliders = Physics.OverlapSphere(transform.position, m_sphereRadius, m_hitLayers);
        }

        return colliders;
    }

    // Call from attack scripts when active
    public void HitboxUpdate()
    {
        // Disabled, don't collide
        if (m_colliderState == EColliderState.closed)
        {
            return;
        }

        // Get colliders overlapping with ours
        Collider[] colliders = OverlapCollider();

        for (int i = 0; i < colliders.Length; i++)
        {
            Collider hit = colliders[i];
            int hitID = hit.GetInstanceID();

            if (!m_objectsHit.Contains(hitID))
            {
                m_hitboxListener?.CollidedWith(hit);
                m_objectsHit.Add(hitID);
            }
        }

        // Update state
        m_colliderState = (colliders.Length > 0) ? EColliderState.colliding : EColliderState.open;
    }

    public void SetListener(IHitboxListener _listener)
    {
        m_hitboxListener = _listener;
    }

    public void EnableCollisions()
    {
        m_colliderState = EColliderState.open;
        m_objectsHit.Clear();
    }

    public void DisableCollisions()
    {
        m_colliderState = EColliderState.closed;
        m_objectsHit.Clear();
    }

    private void OnDrawGizmos()
    {
        Color fadedColor = m_colliderStateColors[(int)m_colliderState];
        fadedColor.a = 0.3f;
        Gizmos.color = fadedColor;

        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale);
        
        if (m_shape == EColliderShape.cube)
        {
            Gizmos.DrawCube(Vector3.zero, new Vector3(m_cubeHalfExtents.x * 2.0f, m_cubeHalfExtents.y * 2.0f, m_cubeHalfExtents.z * 2.0f));
        }
        // Sphere for now
        else
        {
            Gizmos.DrawSphere(Vector3.zero, m_sphereRadius);
        }
        
    }
}
