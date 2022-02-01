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
    public bool create;
    public bool join;

    public void SpawnPlayer()
    {
        Vector2 randomPosition = new Vector2(0,0);
        PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);
        MainCamera.SetActive(false);
        Debug.Log("Successfully spawned player");
    }
    
    private void Start()
    {
        create = CreateRoom.create;
        join = JoinRoom.join;
        if( join )
        {
            roomId = JoinRoom.roomId;
        }
        else
        {
            roomId = CreateRoom.roomId; 
        }
        Debug.Log("Connecting");
        PhotonNetwork.ConnectUsingSettings();
    } 

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        Debug.Log("Connected");
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Joined Lobby");
        if( join )
        {
            joinRoom();
        }
        else{
            createRoom();
        }
    }

    public void createRoom()
    {
        PhotonNetwork.CreateRoom(roomId);
        Debug.Log("Created Room");
        Debug.Log("Room id = ");
        Debug.Log(roomId);
        
    }

    public void joinRoom()
    {
        PhotonNetwork.JoinRoom("Room1");
        Debug.Log("Joined Room");
        Debug.Log("Room id = ");
        Debug.Log(roomId);
    }

    public override void OnJoinedRoom()
    {
        /*Vector2 randomPosition = new Vector2(0,0);
        PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);
        Debug.Log("Instantiation completed");*/
        SpawnPlayer();
    }
}
