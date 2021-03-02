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
    private static string SAVE_FOLDER;

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
        Levels newLevel = new Levels();
        newLevel.ActiveButtons = activeButtons;
        newLevel.StartTile = startTile;
        newLevel.EndTile = endTile;
        var jsonValue = JsonUtility.ToJson(newLevel);

//#if UNITY_ANDROID
//        SAVE_FOLDER = Application.persistentDataPath + "/Resources/Levels.json";
//#else
        SAVE_FOLDER = Application.dataPath + "/Resources/Levels.json";
//#endif
        //if (!Directory.Exists(SAVE_FOLDER))
        //{
        //    Directory.CreateDirectory(SAVE_FOLDER);
        //}

        File.WriteAllText(SAVE_FOLDER, jsonValue);
    }
}

[System.Serializable]
public class Levels {
    public List<string> ActiveButtons;
    public string StartTile;
    public string EndTile;
}
