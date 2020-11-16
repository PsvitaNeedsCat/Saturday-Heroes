using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotation : MonoBehaviour
{
    private enum Axis
    {
        x,
        y,
        z,
    }
    [SerializeField] private Axis m_rotationAxis = Axis.y;

    [SerializeField] private float m_rotationSpeed = 30.0f;
    private float m_xModifier;
    private float m_yModifier;
    private float m_zModifier;

    private void Awake()
    {
        m_xModifier = (m_rotationAxis == Axis.x) ? m_rotationSpeed : 0.0f;
        m_yModifier = (m_rotationAxis == Axis.y) ? m_rotationSpeed : 0.0f;
        m_zModifier = (m_rotationAxis == Axis.z) ? m_rotationSpeed : 0.0f;
    }

    private void OnEnable()
    {
        StartCoroutine(Spin());
    }

    private IEnumerator Spin()
    {
        while (true)
        {
            Vector3 euler = transform.rotation.eulerAngles;
            float x = (m_xModifier == 0.0f) ? euler.x : Time.time * m_xModifier;
            float y = (m_yModifier == 0.0f) ? euler.y : Time.time * m_yModifier;
            float z = (m_zModifier == 0.0f) ? euler.z : Time.time * m_zModifier;
            transform.rotation = Quaternion.Euler(x, y, z);

            yield return null;
        }
    }
}
