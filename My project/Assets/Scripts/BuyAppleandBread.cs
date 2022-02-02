using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuyAppleandBread : MonoBehaviour
{
    // Start is called before the first frame update
    // public GameManager gameManager;
    // public GameObject BuyAppleAndBreadGameObject;

    public int applePrice, breadPrice;
    void Start()
    {
        applePrice = 1;
        breadPrice = 2;
        SetVisibility(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetVisibility(bool visible){
        // this.gameObject.SetActive(visible);
    }

}
