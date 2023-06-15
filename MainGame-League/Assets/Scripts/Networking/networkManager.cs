using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;
using UnityEngine.SceneManagement;
using Photon.Pun.Demo.Cockpit.Forms;

public class networkManager : MonoBehaviourPunCallbacks
{
    int state = 0;
    int numOfPlayersReady = 0;

    bool inQueue = false;
    bool readyBool = false;

    public int maxPlayers;

    float currentTime;
    int minutes;
    int seconds;

    [SerializeField]
    public GameObject joinGameButton;
    public GameObject findMatchButton;
    public GameObject readyButton;
    public GameObject ready;

    public TMP_Text queueTimer;

    public GameObject MrHan;
    public GameObject Camera;
    public Transform blueSpawn;

    public Scene mainGame;
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();

        findMatchButton.SetActive(false);
        readyButton.SetActive(false);
        
        state = 0;
        //numOfPlayersReady = 0;
    }

    void Update()
    {
        if (state == 3)
        {
            currentTime += Time.deltaTime;
            minutes = (int)(currentTime / 60);
            seconds = (int)(currentTime % 60);
        }

        if (inQueue)
        {
            queueTimer.SetText("Waiting for players...(" + PhotonNetwork.PlayerList.Length.ToString() + "/" + maxPlayers + ")");
        }
        if (readyBool)
        {
            queueTimer.SetText("Players Ready: " + numOfPlayersReady + "/" + maxPlayers);
        }

        if (PhotonNetwork.InRoom == true && PhotonNetwork.PlayerList.Length == maxPlayers)
        {
            ready.GetComponent<Image>().color = Color.green;
        }

      
    }


    public void JoinGame()
    {
        findMatchButton.SetActive(true);
        joinGameButton.SetActive(false);
    }

    public void FindMatch()
    {
        if (state == 2)
        {
            base.OnJoinedLobby();
            PhotonNetwork.JoinOrCreateRoom("test", null, null);
            findMatchButton.SetActive(false);
            readyButton.SetActive(true);
            inQueue = true;
        }

    }

    public void Ready()
    {

        if (state == 1 && !readyBool && PhotonNetwork.PlayerList.Length == maxPlayers)
        {
            numOfPlayersReady ++;
            inQueue = false;
            readyBool = true;

            if (numOfPlayersReady == maxPlayers)
            {
                base.OnJoinedRoom();
                GameObject player = PhotonNetwork.Instantiate(MrHan.name, blueSpawn.position, Quaternion.identity);
                player.GetComponent<playerSetup>().isLocalPlayer();
                Camera playerCam = PhotonNetwork.Instantiate(Camera.name, blueSpawn.position, Quaternion.identity).GetComponent<Camera>();
            }
        }
        Debug.Log(numOfPlayersReady);
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        PhotonNetwork.JoinLobby();

    }

    public override void OnJoinedLobby()
    {
        state = 2;
    }

    public override void OnJoinedRoom()
    {
        state = 1;

    }

    
}
