using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyMaskandSanitizer : MonoBehaviour
{
    // Start is called before the first frame update
    // public GameManager gameManager;
    // public GameObject BuyMaskAndSanitizerGameObject;

    public int maskPrice, sanitizerPrice;
    void Start()
    {
        maskPrice = 1;
        sanitizerPrice = 2;
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
