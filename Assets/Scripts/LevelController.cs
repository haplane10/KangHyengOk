using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject Tiles;
    [SerializeField] Stage stage;
    [SerializeField] GameObject goal;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        SetTiles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetTiles()
    {
        stage = GameManager.Instance.Bebot.Stages[GameManager.Instance.Level - 1];

        foreach (var tile in stage.ActiveButtons)
        {
            GameObject.Find(tile).GetComponent<Image>().color = Color.white;
        }

        player.GetComponent<RectTransform>().anchoredPosition = GameObject.Find(stage.StartTile).GetComponent<RectTransform>().anchoredPosition;
        goal.GetComponent<RectTransform>().anchoredPosition = GameObject.Find(stage.EndTile).GetComponent<RectTransform>().anchoredPosition;
    }
}
