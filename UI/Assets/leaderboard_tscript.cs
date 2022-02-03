using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class leaderboard_tscript : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<string> highscoreEntryTransformList;

    private void Awake(){
        List<string> highscoreEntryList = new List<string>() {"LEO","RON","NEY","HAALAND","LEWY","KEVIN"};
        Hola(highscoreEntryList);
    }

    private void Hola(List<string> highscoreEntryList){
        entryContainer = transform.Find("entry_container");
        entryTemplate = entryContainer.Find("entry_template");
        entryTemplate.gameObject.SetActive(false);
    
        

        highscoreEntryTransformList = new List<string>();
        foreach (string highscoreEntry in highscoreEntryList) {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
    }
    
    private void CreateHighscoreEntryTransform(string highscoreEntry, Transform container, List<string> transformList) {

        float templateHeight = 35f;
        // for(int i=0; i<transformList.Count+1; i++){
            Transform entryTransform =  Instantiate(entryTemplate, container);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
            entryTransform.gameObject.SetActive(true);

            int rank = transformList.Count+1;
            string rankString;
            switch(rank){
                default:
                    rankString = rank + "."; break;
            }

            entryTransform.Find("pos").GetComponent<TMPro.TextMeshProUGUI>().text = rankString;

            string name = highscoreEntry;
            entryTransform.Find("name").GetComponent<TMPro.TextMeshProUGUI>().text = name;

            transformList.Add(name);
            
        // } 
    }
    
}

