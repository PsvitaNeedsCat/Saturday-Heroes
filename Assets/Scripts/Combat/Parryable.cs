using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parryable : MonoBehaviour
{
    [HideInInspector] public System.Action m_parryAction = null;

    public float m_manaValue;
    public Transform m_root;

    public void OnParried()
    {
        m_parryAction?.Invoke();

        Destroy(m_root.gameObject);
    }
}
