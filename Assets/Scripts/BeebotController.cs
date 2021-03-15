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
    public List<Direction> directions = new List<Direction>();
    [SerializeField] List<Sprite> arrowSprite = new List<Sprite>();
    [SerializeField] List<Image> moveArrow = new List<Image>();
    bool isStop;
    public int currentMoveIndex = 0;
    public GameObject finishPanel;
    public Text finishText;
    public bool isSuccess;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FinishGame() // true : SUCCESS    false : FAIL
    {
        finishPanel.SetActive(true);
        finishText.text = (isSuccess == true) ? "SUCCESS" : "FAIL";

        //if (isSuccess == true)
        //{
        //    finishText.text = "SUCCESS";
        //}
        //else
        //{
        //    finishText.text = "FAIL";
        //}
    }

    public void Forward()
    {
        directions.Add(Direction.Forward);
        moveArrow[directions.Count - 1].sprite = arrowSprite[1];
        moveArrow[directions.Count - 1].color = Color.white;
    }

    public void Backward()
    {
        directions.Add(Direction.Backward);
        moveArrow[directions.Count - 1].sprite = arrowSprite[3];
        moveArrow[directions.Count - 1].color = Color.white;
    }

    public void LeftTurn()
    {
        directions.Add(Direction.TurnLeft);
        moveArrow[directions.Count - 1].sprite = arrowSprite[0];
        moveArrow[directions.Count - 1].color = Color.white;
    }

    public void RightTurn()
    {
        directions.Add(Direction.TurnRight);
        moveArrow[directions.Count - 1].sprite = arrowSprite[2];
        moveArrow[directions.Count - 1].color = Color.white;
    }

    public void PlayBeebot()
    {
        StartCoroutine(MoveBeebot());
    }

    IEnumerator MoveBeebot()
    {
        for (int i = 0; i < directions.Count; i++)
        {
            currentMoveIndex = i;
            moveArrow[i].color = new Color(0.8f, 1f, 0f, 1f);
            switch (directions[i])
            {
                case Direction.Forward:
                    StartCoroutine(BeebotForward());
                    break;

                case Direction.Backward:
                    StartCoroutine(BeebotBackward());
                    break;

                case Direction.TurnLeft:
                    StartCoroutine(BeebotLeftTurn());
                    break;

                case Direction.TurnRight:
                    StartCoroutine(BeebotRightTurn());
                    break;

                default:
                    break;
            }

            yield return new WaitUntil(() => isStop == true);
        }

        FinishGame();
        directions.Clear();
    }
    
    IEnumerator BeebotForward()
    {
        isStop = false;
        if ((int)beebot.localEulerAngles.z == 90)
        {
            var value = beebot.anchoredPosition.x - 150;
            while (beebot.anchoredPosition.x != value)
            {
                beebot.anchoredPosition = Vector2.MoveTowards(beebot.anchoredPosition, new Vector2(value, beebot.anchoredPosition.y), 100 * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            isStop = true;
        }

        if ((int)beebot.localEulerAngles.z == 270)
        {
            var value = beebot.anchoredPosition.x + 150;
            while (beebot.anchoredPosition.x != value)
            {
                beebot.anchoredPosition = Vector2.MoveTowards(beebot.anchoredPosition, new Vector2(value, beebot.anchoredPosition.y), 100 * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            isStop = true;
        }

        if ((int)beebot.localEulerAngles.z == 0)
        {
            var value = beebot.anchoredPosition.y + 150;
            while (beebot.anchoredPosition.y != value)
            {
                beebot.anchoredPosition = Vector2.MoveTowards(beebot.anchoredPosition, new Vector2(beebot.anchoredPosition.x, value), 100 * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            isStop = true;
        }

        if ((int)beebot.localEulerAngles.z == 180)
        {
            var value = beebot.anchoredPosition.y - 150;
            while (beebot.anchoredPosition.y != value)
            {
                beebot.anchoredPosition = Vector2.MoveTowards(beebot.anchoredPosition, new Vector2(beebot.anchoredPosition.x, value), 100 * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            isStop = true;
        }
        
    }

    IEnumerator BeebotBackward()
    {
        isStop = false;
        if ((int)beebot.localEulerAngles.z == 90)
        {
            var value = beebot.anchoredPosition.x + 150;
            while (beebot.anchoredPosition.x != value)
            {
                beebot.anchoredPosition = Vector2.MoveTowards(beebot.anchoredPosition, new Vector2(value, beebot.anchoredPosition.y), 100 * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            isStop = true;
        }

        if ((int)beebot.localEulerAngles.z == 270)
        {
            var value = beebot.anchoredPosition.x - 150;
            while (beebot.anchoredPosition.x != value)
            {
                beebot.anchoredPosition = Vector2.MoveTowards(beebot.anchoredPosition, new Vector2(value, beebot.anchoredPosition.y), 100 * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            isStop = true;
        }

        if ((int)beebot.localEulerAngles.z == 0)
        {
            var value = beebot.anchoredPosition.y - 150;
            while (beebot.anchoredPosition.y != value)
            {
                beebot.anchoredPosition = Vector2.MoveTowards(beebot.anchoredPosition, new Vector2(beebot.anchoredPosition.x, value), 100 * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            isStop = true;
        }

        if ((int)beebot.localEulerAngles.z == 180)
        {
            var value = beebot.anchoredPosition.y + 150;
            while (beebot.anchoredPosition.y != value)
            {
                beebot.anchoredPosition = Vector2.MoveTowards(beebot.anchoredPosition, new Vector2(beebot.anchoredPosition.x, value), 100 * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            isStop = true;
        }
    }

    IEnumerator BeebotLeftTurn()
    {
        isStop = false;
        for (int i = 0; i < 90; i++)
        {
            beebot.Rotate(new Vector3(beebot.localEulerAngles.x, beebot.localEulerAngles.y, beebot.localEulerAngles.y + 1));
            yield return new WaitForEndOfFrame();
        }
        isStop = true;
    }

    IEnumerator BeebotRightTurn()
    {
        isStop = false;
        for (int i = 0; i < 90; i++) 
        {
            beebot.Rotate(new Vector3(beebot.localEulerAngles.x, beebot.localEulerAngles.y, beebot.localEulerAngles.y - 1));
            yield return new WaitForEndOfFrame();
        }
        isStop = true;
    }
}
