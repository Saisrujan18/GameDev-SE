using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using ExitGames.Client.Photon;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{

    public GameObject playerPrefab;
    public GameObject MainCamera;
    public string roomId;
    public string username;
    public bool create;
    public bool join;

    public void SpawnPlayer()
    {
        Vector2 randomPosition = new Vector2(0,0);
        PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);
        MainCamera.SetActive(false);
        Debug.Log("Successfully spawned player");
        Debug.Log("Player's name = " + PhotonNetwork.NickName);
    }
    
    private void Start()
    {
        SpawnPlayer();
    } 
}
