using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform m_billboardedObject;

    private Camera m_cam;

    private void Awake()
    {
        m_cam = Camera.main;
    }

    private void LateUpdate()
    {
        m_billboardedObject.LookAt(m_billboardedObject.position + m_cam.transform.rotation * Vector3.forward, m_cam.transform.rotation * Vector3.up);
    }
}
