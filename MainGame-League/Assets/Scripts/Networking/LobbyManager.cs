using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public InputField roomName;

    public GameObject lobbyPanel;
    public GameObject roomPanel;

    public Text roomNameText;

    public RoomItem roomItemPrefab;
    List<RoomItem> roomItemsList = new List<RoomItem>();
    public Transform contentObject;

    private void Start()
    {
        PhotonNetwork.JoinLobby();
    }

    public void OnClickRoomCreate()
    {
        if (roomName.text.Length >= 1)
        {
            PhotonNetwork.CreateRoom(roomName.text, new RoomOptions () { MaxPlayers = 2});
        }
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        lobbyPanel.SetActive(false);
        roomPanel.SetActive(true);
        roomNameText.text = "Room: " + PhotonNetwork.CurrentRoom.Name;
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        base.OnRoomListUpdate(roomList);

        UpdateRoomList(roomList);
    }

    void UpdateRoomList(List<RoomInfo> list)
    {
        foreach ( RoomItem item in roomItemsList)
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

    }

    public override void OnLeftRoom()
    {
        base.OnLeftLobby();
        roomPanel.SetActive(false);
        lobbyPanel.SetActive(true);
        
    }
}
