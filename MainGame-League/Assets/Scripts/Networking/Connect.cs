using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class Connect : MonoBehaviourPunCallbacks
{
    public Text connectText;

    private string usernameString;
    public Text username;

    private GameObject savedNames;
    Register registerScript;

    public void OnConnectPress()
    {
        connectText.text = "Connecting...";
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        SceneManager.LoadScene("Lobby");
    }
}
