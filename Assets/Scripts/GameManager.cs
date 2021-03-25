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

    string levelFile;
    [SerializeField] Bebot bebot;

    public Bebot Bebot { get => bebot; set => bebot = value; }

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
        levelFile = Application.dataPath + "/Resources/Levels/Levels.json";
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
        var StageData = File.ReadAllText(levelFile);

        bebot = JsonUtility.FromJson<Bebot>(StageData);
    }
}
