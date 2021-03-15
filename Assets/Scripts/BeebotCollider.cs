using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeebotCollider : MonoBehaviour
{
    public BeebotController controller;

    private void Start()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {                               //10 - 1 = 9               9    
            if ((controller.directions.Count - 1) == controller.currentMoveIndex)
            {
                Debug.Log("Success");
                controller.isSuccess = true;
            }
        }
    }
}
