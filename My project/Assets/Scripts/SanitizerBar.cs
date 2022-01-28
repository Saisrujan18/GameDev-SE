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

    void Start()
    {
        sanitizerCount = 2;
        sanitizerUsageFactor = 10;
        sanitizerSlider.value = 100;
        text.text = ""+sanitizerCount;
    }

    void IncreaseSanitizerCount(int i)
    {
        sanitizerCount += i;
        text.text = ""+sanitizerCount;
    }

    void DecreaseSanitizerCount(int i)
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
        if( sanitizerSlider.value == 0 )
        {
            DecreaseSanitizerCount(1);
            sanitizerSlider.value = 100;
        }
    }
}
