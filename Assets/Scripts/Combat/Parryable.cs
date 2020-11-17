using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parryable : MonoBehaviour
{
    public float m_manaValue;
    public Transform m_root;

    public void OnParried()
    {
        Destroy(m_root.gameObject);
    }
}
