using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnergyBar : MonoBehaviour
{
    public Slider slider;
    public Gradient Gradient;
    public Image fill;
    float min(float a, float b) {
        return a<b?a:b;
    }
    public void SetEnergy(float Energy)
    {
        slider.value = min(100.0f, Energy);
        fill.color = Gradient.Evaluate(slider.normalizedValue);
    }    
    public void IncrementEnergy(float del){
        SetEnergy(slider.value + del);
    }
}
