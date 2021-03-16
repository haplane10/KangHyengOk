using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    private Button[] buttons;

    [SerializeField] List<string> activeButtons;
    [SerializeField] string startTile;
    [SerializeField] string endTile;
    private static string SAVE_FOLDER_FILE;
    [SerializeField] Bebot bebot;
    [SerializeField] int maxStage;

    // Start is called before the first frame update
    void Start()
    {
        buttons = FindObjectsOfType<Button>();
        
        foreach (var btn in buttons)
        {
            if (!btn.gameObject.name.Contains("Reset") && !btn.gameObject.name.Contains("Apply"))
            {
                btn.GetComponent<Image>().color = new Color(0.35f, 0.35f, 0.3f);
                btn.gameObject.AddComponent<StartEndSlot>();
                btn.onClick.AddListener(delegate { OnButtonClick(btn); });
            }
        }

        SAVE_FOLDER_FILE = Application.dataPath + "/Resources/Levels/Levels.json";
        GetLevelFile();
    }

    public void OnButtonClick(Button btn)
    {
        Debug.Log(btn.name);
        if (btn.GetComponent<Image>().color == new Color(0.35f, 0.35f, 0.3f))
        {
            activeButtons.Add(btn.gameObject.name);
            btn.GetComponent<Image>().color = Color.white;
        }
        else
        {
            activeButtons.Remove(btn.gameObject.name);
            btn.GetComponent<Image>().color = new Color(0.35f, 0.35f, 0.3f);
        }
    }

    public void SetStartTile(GameObject obj)
    {
        startTile = obj.name;
    }

    public void SetEndTile(GameObject obj)
    {
        endTile = obj.name;
    }

    public void ResetStartTile()
    {
        startTile = null;
    }

    public void ResetEndTile()
    {
        endTile = null;
    }

    public void SaveInfoFile()
    {
        Stage newStage = new Stage();
        newStage.StageNo = maxStage + 1;
        newStage.ActiveButtons = activeButtons;
        newStage.StartTile = startTile;
        newStage.EndTile = endTile;
        bebot.Stages.Add(newStage);
        var jsonValue = JsonUtility.ToJson(bebot);

        //if (!Directory.Exists(SAVE_FOLDER))
        //{
        //    Directory.CreateDirectory(SAVE_FOLDER);
        //}

        File.WriteAllText(SAVE_FOLDER_FILE, jsonValue);
    }

    public void GetLevelFile()
    {
        var StageData = File.ReadAllText(SAVE_FOLDER_FILE);

        bebot = JsonUtility.FromJson<Bebot>(StageData);
        maxStage = bebot.Stages.Count;
    }
}

[System.Serializable]
public class Bebot
{
    public List<Stage> Stages;
}
[System.Serializable]
public class Stage {
    public int StageNo;
    public List<string> ActiveButtons;
    public string StartTile;
    public string EndTile;
}
