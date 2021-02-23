using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeebotController : MonoBehaviour
{
    public RectTransform beebot;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Forward()
    {
        if ((int)beebot.localEulerAngles.z == 90)
        {
            beebot.anchoredPosition = new Vector2(beebot.anchoredPosition.x - 150, beebot.anchoredPosition.y);
        }

        if ((int)beebot.localEulerAngles.z == 270)
        {
            beebot.anchoredPosition = new Vector2(beebot.anchoredPosition.x + 150, beebot.anchoredPosition.y);
        }

        if ((int)beebot.localEulerAngles.z == 0)
        {
            beebot.anchoredPosition = new Vector2(beebot.anchoredPosition.x, beebot.anchoredPosition.y + 150);
        }

        if ((int)beebot.localEulerAngles.z == 180)
        {
            beebot.anchoredPosition = new Vector2(beebot.anchoredPosition.x, beebot.anchoredPosition.y - 150);
        }
    }

    public void Backward()
    {
        if ((int)beebot.localEulerAngles.z == 90)
        {
            beebot.anchoredPosition = new Vector2(beebot.anchoredPosition.x + 150, beebot.anchoredPosition.y);
        }

        if ((int)beebot.localEulerAngles.z == 270)
        {
            beebot.anchoredPosition = new Vector2(beebot.anchoredPosition.x - 150, beebot.anchoredPosition.y);
        }

        if ((int)beebot.localEulerAngles.z == 0)
        {
            beebot.anchoredPosition = new Vector2(beebot.anchoredPosition.x, beebot.anchoredPosition.y - 150);
        }

        if ((int)beebot.localEulerAngles.z == 180)
        {
            beebot.anchoredPosition = new Vector2(beebot.anchoredPosition.x, beebot.anchoredPosition.y + 150);
        }
    }

    public void LeftTurn()
    {
        beebot.localEulerAngles = new Vector3(beebot.localEulerAngles.x, beebot.localEulerAngles.y, beebot.localEulerAngles.z + 90);
    }

    public void RightTurn()
    {
        beebot.localEulerAngles = new Vector3(beebot.localEulerAngles.x, beebot.localEulerAngles.y, beebot.localEulerAngles.z - 90);
    }
}
