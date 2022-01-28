using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DummyPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public Dialogue dialogue;
    public int currentEnergy;
    public int currentMoney;
    public EnergyBar energybar;
    public Money money;
    public GameObject buyMeds;
    public GameObject buyFood;
    public int currentBread;
    public int currentApples;
    public int sanitizerCount;
    public int maskCount;
    
    public Text bread;
    public Text apple; 

    void Start()
    {
        currentEnergy = 100;
        currentMoney = 100;
        energybar.SetEnergy(currentEnergy);
        money.SetMoney(currentMoney);
        money.SetMoney(100);

        hideFood();
        hideMed();
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown(KeyCode.Space))
        {
            DecreaseEnergy(10);
            IncreaseMoney(10);
            showFood();
            showMed();
            IncreaseApples(1);
            IncreaseBread(1);
        }
    }

    public void IncreaseEnergy(int energy)
    {
        currentEnergy += energy;
        if( currentEnergy > 100 )
        {
            currentEnergy = 100;
        }
        energybar.SetEnergy(currentEnergy);
    }

    public void DecreaseEnergy(int energy)
    {
        currentEnergy -= energy;
        if( currentEnergy < 0 )
        {
            currentEnergy = 0;
        }
        energybar.SetEnergy(currentEnergy);
    }

    public void IncreaseMoney(int m)
    {
        currentMoney += m;
        money.SetMoney(currentMoney);
    }

    public void DecreaseMoney(int m)
    {
        currentMoney -= m;
        if(currentMoney < 0 )
        {
            currentMoney = 0;
        }
        money.SetMoney(currentMoney);
    }

    public void showMed()
    {
        buyMeds.SetActive(true);
    }

    public void hideMed()
    {
        buyMeds.SetActive(false);
    }

    public void showFood()
    {
        buyFood.SetActive(true);
    }

    public void hideFood()
    {
        buyFood.SetActive(false);
    }

    public void IncreaseApples(int a)
    {
        currentApples += a;
        apple.text = "" +currentApples;
    }

    public void DecreaseApples(int a)
    {
        currentApples -= a;
        if( currentApples < 0 )
        {
            currentApples = 0;
        }
        apple.text = ""+currentApples;
    }

    public void IncreaseBread(int b)
    {
        currentBread += b;
        bread.text = ""+currentBread;
    }

    public void DecreaseBread(int b)
    {
        currentBread -= b;
        if( currentBread < 0 )
        {
            currentBread = 0;
        }
        bread.text = ""+currentBread;
    }

    public void DecrementBread()
    {
        DecreaseBread(1);
    }

    public void DecrementApples()
    {
        DecreaseApples(1);
    }
}
