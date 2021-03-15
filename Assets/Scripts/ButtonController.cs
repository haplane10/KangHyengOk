using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Button[] buttons;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var btn in buttons)
        {
            btn.onClick.AddListener(() => GameManager.Instance.EffectAudioSource.Play());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
