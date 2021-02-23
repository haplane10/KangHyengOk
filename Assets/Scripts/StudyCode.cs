using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyCode : MonoBehaviour
{
    int A = 10;
    int B = 20;
    int C = 30;
    int Z = 10;
    int AA ;
    int AB;

    int[] numbers = new int[200];
    List<int> numberss = new List<int>();
    
    void Awake()
    {
        // loop statement
        for (int i = 0; i < numbers.Length; i = i + 1)
        {
            print(numbers[i]);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
