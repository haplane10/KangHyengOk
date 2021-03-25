using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public bool isPlayBGAudio;

    private void Start()
    {
        GameManager.Instance.SetBGAudioStatus(isPlayBGAudio);
    }

    public void ResetScene(string txt)
    {
        SceneManager.LoadScene(txt);
    }

    public void ChangeScene(string txt)
    {
        SceneManager.LoadScene(txt);
    }

    public void NextScene()
    {
        if (GameManager.Instance.NextLevel())
        {
            SceneManager.LoadScene("Game");
        }
        else
        {
            SceneManager.LoadScene("Main");
        }
        
    }
}
