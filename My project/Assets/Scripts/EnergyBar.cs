using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnergyBar : MonoBehaviour
{
    public Slider slider;
    public Gradient Gradient;
    public Image fill;
    
    public void SetEnergy(int Energy)
    {
        slider.value = Energy;
        fill.color = Gradient.Evaluate(slider.normalizedValue);
    }
}
