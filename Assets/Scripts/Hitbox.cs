using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public LayerMask m_hitLayers;
    public Vector3 m_halfExtents;

    public void TryHit()
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, m_halfExtents, transform.rotation, m_hitLayers);

        Debug.Log("Hit " + colliders.Length + " colliders");
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 200, 100), "Try hit"))
        {
            TryHit();
        }
    }

    private void OnDrawGizmos()
    {
        Color fadedRed = Color.red;
        fadedRed.a = 0.3f;
        Gizmos.color = fadedRed;

        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale);

        Gizmos.DrawCube(Vector3.zero, new Vector3(m_halfExtents.x * 2.0f, m_halfExtents.y * 2.0f, m_halfExtents.z * 2.0f));
    }
}
