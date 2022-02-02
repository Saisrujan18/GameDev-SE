using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanitizerBar : MonoBehaviour
{

    public Slider sanitizerSlider;
    public Text text;
    public int sanitizerCount;
    public int sanitizerUsageFactor;
    public float lastSanitized = 0.0f;

    void Start()
    {
        sanitizerCount = 2;
        sanitizerUsageFactor = 10;
        sanitizerSlider.value = 100;
        text.text = ""+sanitizerCount;
    }

    public void IncreaseSanitizerCount(int i)
    {
        sanitizerCount += i;
        text.text = ""+sanitizerCount;
    }

    public void DecreaseSanitizerCount(int i)
    {
        sanitizerCount -= i;
        if( sanitizerCount < 0 )
        {
            sanitizerCount = 0;
        }
        text.text = ""+sanitizerCount;
    }

    public void DecrementSanitizer()
    {
        sanitizerSlider.value -= 10;
        lastSanitized = Time.time;
        if( sanitizerSlider.value == 0 )
        {
            DecreaseSanitizerCount(1);
            sanitizerSlider.value = 100;
        }
    }
}
