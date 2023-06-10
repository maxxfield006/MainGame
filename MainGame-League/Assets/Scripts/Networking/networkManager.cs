using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class networkManager : Photon.MonoBehaviour
{
    int state = 0;

    public int maxPlayers;


    void Start()
    {
        state = 0;
    }


    void Update()
    {
        
    }

    void OnGUI()
    {
        switch (state)
        {

            //start
            case 0:
                if (GUI.Button(new Rect(10, 10, 200, 200), "Join A Lobby"))
                {
                    PhotonNetwork.ConnectUsingSettings("V0");
                    state = 4;
                }
                break;

            //connected to server
            case 1:
                if (GUI.Button(new Rect(10, 10, 200, 200), "1v1"))
                {
                    PhotonNetwork.JoinLobby();
                    state = 4;
                }
                
                break;

            //connected to lobby
            case 2:
                if (GUI.Button(new Rect(10, 10, 200, 200), "Find match"))
                {
                    PhotonNetwork.JoinRandomRoom();
                    state = 5;
                }
                break;
            //connected to game
            case 3:

                break;

            //break
            case 4:

                break;

            //matchmaking
            case 5:
                GUI.Label(new Rect(10, Screen.height - 50, 200, 30), "Players: " + PhotonNetwork.playerList.Length.ToString() + "/" + maxPlayers);

                if(PhotonNetwork.inRoom == true && PhotonNetwork.playerList.Length == maxPlayers)
                {
                    StartGame();
                    state = 3;
                }
                break;
        }
    }

    void OnConnectedToPhoton()
    {
        state = 1;
    }

    void OnJoinedLobby()
    {
        state = 2;
    }

    void OnPhotonRandomJoinedFailed()
    {
        PhotonNetwork.CreateRoom(null);
    }

    void StartGame()
    {

    }
}
