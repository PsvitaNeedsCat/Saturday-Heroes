using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillBar : MonoBehaviour
{
    private float m_maximum;

    private void Awake()
    {
        m_maximum = transform.localScale.y;
    }

    public float FillAmount
    {
        get
        {
            float current = transform.localScale.y;
            return (current == 0.0f) ? 0.0f : current / m_maximum;
        }
        set
        {
            float newValue = Mathf.Lerp(0.0f, m_maximum, value);

            Vector3 scale = transform.localScale;
            scale.y = newValue;
            transform.localScale = scale;
        }
    }
}
