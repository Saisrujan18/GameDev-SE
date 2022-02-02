using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bread : MonoBehaviour
{
    private int BreadCount;
    public Text bread;
    public Dummy dummy;
    
    void Start()
    {
        BreadCount = 5;
    }

    public void IncreaseBread( int i )
    {
        BreadCount += i;
        bread.text = "" + BreadCount;
    }
    
    public void DecreaseBread(int b)
    {
        BreadCount -= b;
        if( BreadCount < 0 )
        {
            BreadCount = 0;
        }
        else {
            dummy.energybar.SetEnergy(dummy.energybar.slider.value + 20);
        }
        bread.text = "" + BreadCount;
        //TODO:
    }
    
    public void DecrementBread()
    {
        DecreaseBread(1);
    }

}
