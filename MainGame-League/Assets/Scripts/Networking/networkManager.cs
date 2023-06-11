using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class networkManager : MonoBehaviourPunCallbacks
{
    int state = 0;

    public int maxPlayers;

    public GameObject mainGame;
    public GameObject joinLobby;

    float currentTime;
    int minutes;
    int seconds;

    public GameObject mrHan;

    [Space]
    public Transform spawnPosition;

    void Start()
    {
        state = 0;
        
    }


    void Update()
    {
        if (state == 5)
        {
            currentTime += Time.deltaTime;
            minutes = (int)(currentTime / 60);
            seconds = (int)(currentTime % 60);
        }
        
    }

    void OnGUI()
    {
        GUIStyle styleBut = GUI.skin.GetStyle("Button");
        styleBut.fontSize = 60;

        GUIStyle styleLab = GUI.skin.GetStyle("Label");
        styleLab.fontSize = 60;

        switch (state)
        {

            //start
            case 0:
                if (GUI.Button(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 100, 600, 150), "Join a Game"))
                {
                    PhotonNetwork.ConnectUsingSettings();
                    state = 4;
                }
                break;

            //connected to server
            case 1:
                if (GUI.Button(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 100, 600, 150), "1v1"))
                {
                    state = 4;
                }
                
                break;

            //connected to lobby
            case 2:
                if (GUI.Button(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 100, 600, 150), "Find Match"))
                {
                    PhotonNetwork.JoinRandomRoom();
                    state = 5;
                }
                break;
            //connected to game
            case 3:
                mainGame.SetActive(true);
                GameObject player = PhotonNetwork.Instantiate(mrHan.name, spawnPosition.position, Quaternion.identity);
                player.GetComponent<playerSetup>().isLocalPlayer();
                break;

            //break
            case 4:

                break;

            //matchmaking
            case 5:
                GUI.Label(new Rect(Screen.width / 2 - 130, Screen.height / 2 - 80, 800, 100), "Queue: " + seconds, styleLab);

                GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height / 2 , 800, 100), "Waiting for players (" + PhotonNetwork.PlayerList.Length.ToString() + "/" + maxPlayers + ")...", styleLab);

                if(PhotonNetwork.InRoom == true && PhotonNetwork.PlayerList.Length == maxPlayers)
                {
                    StartGame();
                    state = 3;
                }
                break;
        }
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        state = 1;
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        PhotonNetwork.JoinOrCreateRoom("test", null, null);
        state = 2;
    }


    void StartGame()
    {

    }
}
