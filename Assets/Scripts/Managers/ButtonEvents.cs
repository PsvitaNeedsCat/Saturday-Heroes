﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class ButtonEvents : MonoBehaviour
{
    public void LoadScene(string _scene)
    {
        SceneManager.LoadScene(_scene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
