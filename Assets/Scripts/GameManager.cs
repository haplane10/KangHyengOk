using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int Level = 1;
    public AudioSource BGAudioSource;
    public AudioSource EffectAudioSource;

    [SerializeField] private SendToGoogle sendToGoogle;

    string levelFile;
    [SerializeField] Bebot bebot;
    [SerializeField] Report report;

    public Bebot Bebot { get => bebot; set => bebot = value; }
    public Report Report { get => report; set => report = value; }

    public bool NextLevel()
    {
        Level++;
        if (Level <= bebot.Stages.Count)
        {
            return true;
        }

        Level = 1;
        return false;
    }

    public void SendDataToGoogle()
    {
        sendToGoogle.Send(report);
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadLevelDatas();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBGAudioStatus(bool isPlay)
    {
        if (isPlay)
        {
            if (!BGAudioSource.isPlaying)
                BGAudioSource.Play();
        }
        else
            BGAudioSource.Pause();
    }

    private void LoadLevelDatas()
    {
        var levelFile = (TextAsset)Resources.Load("Levels/Levels");
        bebot = JsonUtility.FromJson<Bebot>(levelFile.text);
    }
}

[System.Serializable]
public class Report
{
    public string ID;
    public string Stage;
    public string Solve;
    public string Success;
    public string NextMove;
}
