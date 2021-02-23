using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Direction
{
    None,
    Forward,
    Backward,
    TurnLeft,
    TurnRight,
    MAX
}

public class BeebotController : MonoBehaviour
{
    public RectTransform beebot;
    [SerializeField] List<Direction> directions = new List<Direction>();

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
        directions.Add(Direction.Forward);
    }

    public void Backward()
    {
        directions.Add(Direction.Backward);
    }

    public void LeftTurn()
    {
        directions.Add(Direction.TurnLeft);
    }

    public void RightTurn()
    {
        directions.Add(Direction.TurnRight);
    }

    public void PlayBeebot()
    {
        StartCoroutine(MoveBeebot());
    }

    IEnumerator MoveBeebot()
    {
        for (int i = 0; i < directions.Count; i++)
        {
            switch (directions[i])
            {
                case Direction.Forward:
                    BeebotForward();
                    break;

                case Direction.Backward:
                    BeebotBackward();
                    break;

                case Direction.TurnLeft:
                    BeebotLeftTurn();
                    break;

                case Direction.TurnRight:
                    BeebotRightTurn();
                    break;

                default:
                    break;
            }

            yield return new WaitForSeconds(1);
        }

        directions.Clear();
    }

    public void BeebotForward()
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

    public void BeebotBackward()
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

    public void BeebotLeftTurn()
    {
        beebot.localEulerAngles = new Vector3(beebot.localEulerAngles.x, beebot.localEulerAngles.y, beebot.localEulerAngles.z + 90);
    }

    public void BeebotRightTurn()
    {
        beebot.localEulerAngles = new Vector3(beebot.localEulerAngles.x, beebot.localEulerAngles.y, beebot.localEulerAngles.z - 90);
    }
}
