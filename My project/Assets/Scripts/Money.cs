using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public Text money;

    public void SetMoney(int m)
    {
        money.text = ""+m;
    }
}
