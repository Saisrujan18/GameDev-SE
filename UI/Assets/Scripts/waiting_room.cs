using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class waiting_room : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<string> transformList = new List<string>();

    private void Awake(){
        List<string> highscoreEntryList = new List<string>() {"LEO","RON","NEY","HAALAND","LEWY","KEVIN"};
        for(int i=0; i<6; i++){
            Hola(highscoreEntryList, i);
        }
        
    }
    private void Hola(List<string> highscoreEntryList, int i){
        entryContainer = transform.Find("entry_container");
        entryTemplate = entryContainer.Find("entry_template");
        entryTemplate.gameObject.SetActive(false);
    
            CreateHighscoreEntryTransform(highscoreEntryList[i], entryContainer);
    }
    private void CreateHighscoreEntryTransform(string highscoreEntry, Transform container) {

        float templateHeight = 35f;
      
            Transform entryTransform =  Instantiate(entryTemplate, container);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
            entryTransform.gameObject.SetActive(true);

            // int rank = transformList.Count+1;
            // string rankString;
            // switch(rank){
            //     default:
            //         rankString = rank + "."; break;
            // }

            // entryTransform.Find("pos").GetComponent<TMPro.TextMeshProUGUI>().text = "";

            string name = highscoreEntry;
            entryTransform.Find("name").GetComponent<TMPro.TextMeshProUGUI>().text = "- "+name;

            transformList.Add(name);  
    }
    
}