using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class leaderboard_table : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;

    private void Awake(){
        entryContainer = transform.Find("entry_container");
        entryTemplate = entryContainer.Find("entry_template");

        entryTemplate.gameObject.SetActive(false);

         float templateHeight = 30f;
         for(int i=0; i<5; i++){
             Transform entryTransform =  Instantiate(entryTemplate, entryContainer);
             RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
            entryTransform.gameObject.SetActive(true);

            int rank = i+1;
            string rankString;
            switch(rank){
                default:
                    rankString = rank + "TH"; break;
                case 1: rankString = "1ST"; break;
                case 2: rankString = "2ND"; break;
                case 3: rankString = "3RD"; break;
            }

            entryTransform.Find("pos").GetComponent<Text>().text = rankString;

            string name = "LM10";
            entryTransform.Find("name").GetComponent<Text>().text = name;
            
         }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
