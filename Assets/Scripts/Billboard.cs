﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform m_billboardedObject = null;

    private Camera m_cam;

    private void Awake()
    {
        m_cam = Camera.main;
    }

    private void LateUpdate()
    {
        BillboardObject();
    }

    public void BillboardObject()
    {
        if (m_billboardedObject == null)
        {
            m_billboardedObject = transform;
        }

        m_cam = Camera.main;
        m_billboardedObject.LookAt(m_billboardedObject.position + m_cam.transform.rotation * Vector3.forward, m_cam.transform.rotation * Vector3.up);
    }
}
