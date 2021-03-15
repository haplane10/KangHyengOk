﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void ResetScene(string txt)
    {
        SceneManager.LoadScene(txt);
    }

    public void ChangeScene(string txt)
    {
        SceneManager.LoadScene(txt);
    }
}
