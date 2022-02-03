using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using ExitGames.Client.Photon;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using TMPro;

public class CreateRoom : MonoBehaviourPunCallbacks
{
    public static string roomId;
    public GameObject roomtext;
    public GameObject usertext;
    public static bool create;
    public static string username;
    
    void Begin()
    {
        roomId = roomtext.GetComponent<TMP_InputField>().text;
        create = true;
        username = usertext.GetComponent<TMP_InputField>().text;
        SceneManager.LoadScene("Waiting Room"); 
    }
}
