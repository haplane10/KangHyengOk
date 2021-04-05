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
        GameManager.Instance.Report.NextMove = (txt.Contains("Game") ? GameManager.Instance.Level.ToString() : "Main");
        GameManager.Instance.SendDataToGoogle();
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
            GameManager.Instance.Report.NextMove = GameManager.Instance.Level.ToString();
            GameManager.Instance.SendDataToGoogle();
            SceneManager.LoadScene("Game");
        }
        else
        {
            GameManager.Instance.Report.NextMove = "Finish";
            GameManager.Instance.SendDataToGoogle();
            SceneManager.LoadScene("Main");
        }
        
    }
}
