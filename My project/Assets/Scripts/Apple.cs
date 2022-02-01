using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Apple : MonoBehaviour
{
    private int AppleCount;
    public Text apple;
    
    void Start()
    {
        AppleCount = 5;
    }

    public void IncreaseApples( int i )
    {
        AppleCount += i;
        apple.text = "" + AppleCount;
    }
    
    public void DecreaseApples(int d)
    {
        AppleCount -= d;
        if( AppleCount < 0 )
        {
            AppleCount = 0;
        }
        apple.text = "" + AppleCount;
    }
    
    public void DecrementApples()
    {
        DecreaseApples(1);
    }
}
