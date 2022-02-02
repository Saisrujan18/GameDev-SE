using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public Text moneyText;
    public int money = 0;
    void Start(){
        SetMoney(100);
    }
    public void SetMoney(int m)
    {
        money = m;
        moneyText.text = ""+m;
    }
    public void IncrementMoney(int del) {
        SetMoney(money + del);
    }
    public void DecrementMoney(int del) {
        SetMoney(money - del);
    }
}
