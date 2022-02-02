using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaskBar : MonoBehaviour
{
    public Slider maskSlider;
    public Text text;
    public int MaskCount;
    public float maskDegradeFactor;

    void Start()
    {
        MaskCount = 2;
        maskDegradeFactor = 1f;
        maskSlider.value = 100;
    }

    public void IncreaseMaskCount(int i)
    {
        MaskCount += i;
        text.text = ""+MaskCount;
    }

    public void DecreaseMaskCount(int i)
    {
        MaskCount -= i;
        if( MaskCount < 0 )
        {
            MaskCount = 0;
        }
        text.text = ""+MaskCount;
    }

    public void Update()
    {
        updateMask();
    }
    
    public void updateMask()
    {
        text.text = ""+MaskCount;
        if( MaskCount == 0 )
        {
            maskSlider.value = 0;
        }
        else
        {
            maskSlider.value = maskSlider.value - Time.deltaTime*maskDegradeFactor;

            if( maskSlider.value < 1 )
            {
                MaskCount -= 1;
                maskSlider.value = 100;
            }
        }
    }
}
