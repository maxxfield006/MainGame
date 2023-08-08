using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using System;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public InputField roomName;

    public GameObject lobbyPanel;
    public GameObject roomPanel;

    public Text roomNameText;
    public Text roomCountText;

    public RoomItem roomItemPrefab;
    List<RoomItem> roomItemsList = new List<RoomItem>();
    public Transform contentObject;

    private float timeBetweenUpdates = 1.5f;
    private float nextUpdateTime;

    public Button createLobby;

    bool inRoom = false;

    public Button startButton;

    int maxPlayers;

    RoomOptions roomOptions;

    bool inLobby;


    public List<string> nickNames = new List<string>() { "Penguin", "Monkey", "Cat", "Dog", "Elephant" };

    private void Start()
    {
        PhotonNetwork.JoinLobby();

        startButton.gameObject.SetActive(false);

        PhotonNetwork.ConnectUsingSettings();

        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    private void Update()
    {

        if (inRoom)
        {
            roomCountText.text = "Room Count: " + PhotonNetwork.CurrentRoom.PlayerCount + " / 6";
        }

        if (PhotonNetwork.CurrentRoom.PlayerCount >= 2)
        {
            startButton.gameObject.SetActive(true);

        }
        else
        {
            startButton.gameObject.SetActive(false);
        }

        if (PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount >= 2)
        {
            startButton.gameObject.SetActive(true);
        }
        else
        {
            startButton.gameObject.SetActive(false);
        }

    }


    public void OnReadyButtonPressed()
    {
        startButton.GetComponent<Image>().color = Color.blue;
        StartCoroutine(waitTillStart());
    }


    public void OnClickRoomCreate()
    {
        if (roomName.text.Length >= 1)
        {
            PhotonNetwork.CreateRoom(roomName.text, new RoomOptions { MaxPlayers = 6});
        }
    }

    IEnumerator waitTillStart()
    {
        yield return new WaitForSeconds(3);
        PhotonNetwork.LoadLevel("FPS");
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        lobbyPanel.SetActive(false);
        roomPanel.SetActive(true);
        roomNameText.text = "Room: " + PhotonNetwork.CurrentRoom.Name;
        inRoom = true;


        int randomName = UnityEngine.Random.Range(0, nickNames.Count);
        PhotonNetwork.NickName = nickNames[randomName];
        nickNames.RemoveAt(randomName);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        base.OnRoomListUpdate(roomList);

        UpdateRoomList(roomList);

        if (Time.time >= nextUpdateTime)
        {

            nextUpdateTime = Time.time + timeBetweenUpdates;
        }

    }

    void UpdateRoomList(List<RoomInfo> list)
    {
        foreach (RoomItem item in roomItemsList)
        {
            Destroy(item.gameObject);
        }
        roomItemsList.Clear();

        foreach (RoomInfo room in list)
        {
            RoomItem newRoom = Instantiate(roomItemPrefab, contentObject);
            newRoom.SetRoomName(room.Name);
            roomItemsList.Add(newRoom);
        }

    }

    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    public void OnClickLeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        startButton.gameObject.SetActive(false);
    }

    public override void OnLeftRoom()
    {
        base.OnLeftLobby();
        roomPanel.SetActive(false);
        lobbyPanel.SetActive(true);

    }
}
