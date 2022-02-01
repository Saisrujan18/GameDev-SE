using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class play_menu : MonoBehaviour
{
    public GameObject exitPanel;
    
    public void QuitGame(){
        if(exitPanel != null){
            exitPanel.SetActive(true);
        }
    }

    public void YesNo(int choice){
        if(choice == 1){
            Application.Quit();
        }
        else if(choice == 0){
            exitPanel.SetActive(false);
        }
        
    }
    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
