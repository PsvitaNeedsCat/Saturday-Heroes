using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Billboard))]
public class BillboardInspector : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Billboard billboard = (Billboard)target;
        if (GUILayout.Button("Billboard"))
        {
            billboard.BillboardObject();
        }
    }
}
