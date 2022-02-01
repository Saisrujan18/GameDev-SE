using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using ExitGames.Client.Photon;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using TMPro;

public class JoinRoom : MonoBehaviour
{
    public static string roomId;
    public GameObject text;
    public static bool join;
    
    void Begin()
    {
        roomId = text.GetComponent<TMP_InputField>().text;
        join = true;
        SceneManager.LoadScene("GameScene"); 
    }
}
