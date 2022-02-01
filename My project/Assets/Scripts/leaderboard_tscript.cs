using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class leaderboard_tscript : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;

    private void Awake(){
        entryContainer = transform.Find("entry_container");
        entryTemplate = entryContainer.Find("entry_template");
        entryTemplate.gameObject.SetActive(false);
    
        highscoreEntryList = new List<HighscoreEntry>() {
            new HighscoreEntry{ name = "LEO"},
            new HighscoreEntry{ name = "RON"},
            new HighscoreEntry{ name = "NEY"},
            new HighscoreEntry{ name = "HAALAND"},
            new HighscoreEntry{ name = "LEWY"},
            new HighscoreEntry{ name = "KEVIN"}
        };

        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscoreEntryList) {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
    }
    
    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList) {
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
                // case 1: rankString = "1ST"; break;
                // case 2: rankString = "2ND"; break;
            // case 3: rankString = "3RD"; break;
            }

            entryTransform.Find("pos").GetComponent<TMPro.TextMeshProUGUI>().text = rankString;

            string name = highscoreEntry.name;
            entryTransform.Find("name").GetComponent<TMPro.TextMeshProUGUI>().text = name;

            transformList.Add(entryTransform);
            
        // } 
    }

    private class HighscoreEntry {
        public string name;
    }
    
}
