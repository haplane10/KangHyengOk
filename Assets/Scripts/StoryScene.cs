using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class StoryScene : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] SceneController sceneController;

    float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(videoPlayer.clip.length);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= videoPlayer.clip.length)
        {
            sceneController.ChangeScene("Game");
        }
    }
}
