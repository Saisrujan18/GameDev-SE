using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class back : MonoBehaviour
{
    public void btn_change_scene(string scene_name){
        Debug.Log("Button Clicked");
        SceneManager.LoadScene("MainMenu"); 
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
