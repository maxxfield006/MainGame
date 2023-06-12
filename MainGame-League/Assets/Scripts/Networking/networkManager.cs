using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;
using UnityEngine.SceneManagement;

public class networkManager : MonoBehaviourPunCallbacks
{
    int state = 0;

    bool inQueue = false;

    public int maxPlayers;

    float currentTime;
    int minutes;
    int seconds;

    public GameObject mrHan;
    public Camera cam;

    [SerializeField]
    private Transform spawnPosition;

    public GameObject joinGameButton;
    public GameObject findMatchButton;
    public GameObject readyButton;
    public GameObject ready;

    public TMP_Text queueTimer;

    void Start()
    {
        findMatchButton.SetActive(false);
        readyButton.SetActive(false);

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

        if (inQueue)
        {
            queueTimer.SetText("Waiting for players...(" + PhotonNetwork.PlayerList.Length.ToString() + "/" + maxPlayers + ")");
        }

        if (PhotonNetwork.InRoom == true && PhotonNetwork.PlayerList.Length == maxPlayers)
        {
            ready.GetComponent<Image>().color = Color.green;
        }

      
    }

    public void JoinGame()
    {
        PhotonNetwork.ConnectUsingSettings();
        findMatchButton.SetActive(true);
        joinGameButton.SetActive(false);
        state = 4;
    }

    public void FindMatch()
    {
        PhotonNetwork.JoinRandomRoom();
       
        findMatchButton.SetActive(false);
        readyButton.SetActive(true);
        state = 5;
        inQueue = true;

    }

    public void Ready()
    {

        if (PhotonNetwork.InRoom == true && PhotonNetwork.PlayerList.Length == maxPlayers)
        {
            SceneManager.LoadScene("mainGame", LoadSceneMode.Single);
            Debug.Log("Shit should be working");
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
