using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bread : MonoBehaviour
{
    public int BreadCount;
    public Text bread;
    
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
        bread.text = "" + BreadCount;
    }
    
    public void DecrementBread()
    {
        DecreaseBread(1);
    }

}
