using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Pun;
using ExitGames.Client.Photon;

public class waiting_room : MonoBehaviourPunCallbacks
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;
    private List<Transform> transformList = new List<Transform>(); 
    
    public string roomId;
    public string username;
    public bool create;
    public bool join;
    public GameObject button;

    private void Awake(){
        entryContainer = transform.Find("entry_container");
        entryTemplate = entryContainer.Find("entry_template");
        entryTemplate.gameObject.SetActive(false);
    }
    
    void Update()
    {
        transformList = new List<Transform>();
        foreach (Photon.Realtime.Player p in PhotonNetwork.PlayerList)
		{
            CreateHighscoreEntryTransform(new HighscoreEntry{ name = p.NickName }, entryContainer);
		}
    }
    
    private void Start()
    {
        create = CreateRoom.create;
        join = JoinRoom.join;
        if( join )
        {
            button.SetActive(false);
            roomId = JoinRoom.roomId;
            username = JoinRoom.username;
        }
        else
        {
            roomId = CreateRoom.roomId; 
            username = CreateRoom.username;
        }
        Debug.Log("Connecting");
        PhotonNetwork.ConnectUsingSettings();
    } 

    public void startGame()
    {
        if( PhotonNetwork.IsMasterClient )
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;
            SceneManager.LoadScene("GameScene"); 
        }
    }
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
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
        Debug.Log("Room id = " + roomId);
        Debug.Log("UserName" + username);
        PhotonNetwork.NickName = username;
    }

    public void joinRoom()
    {
        PhotonNetwork.JoinRoom(roomId);
        Debug.Log("Joined Room");
        Debug.Log("Room id = " + roomId);
        Debug.Log("UserName" + username);
        PhotonNetwork.NickName = username;
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Successfully spawned player");
        Debug.Log("Player's name = " + PhotonNetwork.NickName);
    }
    
    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container) {
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