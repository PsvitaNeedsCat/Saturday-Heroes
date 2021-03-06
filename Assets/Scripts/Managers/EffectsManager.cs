﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EffectsManager : MonoBehaviour
{
    private readonly string m_effectsPath = "Effects";
    private static Dictionary<string, GameObject> s_effectDictionary = new Dictionary<string, GameObject>();
    private static Transform s_transform;

    private void Awake()
    {
        GameObject[] effects = Resources.LoadAll(m_effectsPath, typeof(GameObject)).Cast<GameObject>().ToArray();

        for (int i = 0; i < effects.Length; i++)
        {
            if (!s_effectDictionary.ContainsKey(effects[i].name))
            {
                s_effectDictionary.Add(effects[i].name, effects[i]);
            }
        }
    }

    private void OnEnable()
    {
        s_transform = transform;
    }
    private void OnDisable()
    {
        s_transform = null;
    }

    public static void DestroyActiveEffects()
    {
        foreach (Transform child in s_transform)
        {
            Destroy(child.gameObject);
        }
    }

    // Create an instance of the specified type of effect, and returns a reference to the object created
    public static GameObject SpawnEffect(string _name, Vector3 _position, Quaternion _rotation, Vector3? _scale = null, float _destroyAfter = 1.0f)
    {
        if (s_transform == null)
        {
            Debug.LogError("Tried to spawn an effect without an instance of effects manager, please place the prefab in the scene");
            return null;
        }

        if (_scale == null)
        {
            _scale = Vector3.one;
        }

        // Try to find effect in dictionary
        GameObject effectPrefab = s_effectDictionary[_name];

        // If not found, log an error and return
        if (!effectPrefab)
        {
            Debug.LogError("Effect could not be found with name " + _name);
            return null;
        }

        // Create effect, and modify transform
        GameObject newEffect = Instantiate(effectPrefab, s_transform);
        Destroy(newEffect, _destroyAfter);

        // Set the scaling mode of the 
        ParticleSystem.MainModule mainModule = newEffect.GetComponent<ParticleSystem>().main;
        mainModule.scalingMode = ParticleSystemScalingMode.Hierarchy;

        for (int i = 0; i < newEffect.transform.childCount; i++)
        {
            ParticleSystem ps = newEffect.transform.GetChild(i).GetComponent<ParticleSystem>();
            if (ps)
            {
                ParticleSystem.MainModule module = ps.main;
                module.scalingMode = ParticleSystemScalingMode.Hierarchy;
            }
        }

        newEffect.transform.position = _position;
        newEffect.transform.rotation = _rotation;
        newEffect.transform.localScale = (Vector3)_scale;

        return newEffect;
    }
}
