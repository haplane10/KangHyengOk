using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartEndSlot : MonoBehaviour, IDropHandler
{
    public bool isStart;
    public bool isEnd;
    
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            if (eventData.pointerDrag.GetComponent<DragDrop>().isStart)
            {
                isStart = true;
                FindObjectOfType<Level>().SetStartTile(gameObject);
            }
            else
            {
                isEnd = true;
                FindObjectOfType<Level>().SetEndTile(gameObject);
            }
        }
    }

    public void ResetStart()
    {
        isStart = false;
    }

    public void ResetEnd()
    {
        isEnd = false;
    }
}
