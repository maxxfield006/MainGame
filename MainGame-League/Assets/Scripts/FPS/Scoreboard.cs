using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using System.Numerics;

public class Scoreboard : MonoBehaviourPunCallbacks
{
    [SerializeField] Transform container;
    [SerializeField] GameObject scoreboardItemPrefab;

    CanvasGroup canvasGroup;

    Dictionary<Player, ScoreBoardItem> scoreBoardItems = new Dictionary<Player, ScoreBoardItem>();

    private void Start()
    {
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            AddScoreBoardItem(player);
        }

        canvasGroup = GetComponent<CanvasGroup>();
    }

    void AddScoreBoardItem(Player player)
    {
        ScoreBoardItem item = Instantiate(scoreboardItemPrefab, container).GetComponent<ScoreBoardItem>();
        item.Initialize(player);
        scoreBoardItems[player] = item;
    }

    void RemoveScoreboardItem(Player player)
    {
        Destroy(scoreBoardItems[player].gameObject);
        scoreBoardItems.Remove(player);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddScoreBoardItem(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        RemoveScoreboardItem(otherPlayer);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            canvasGroup.alpha = 1;
        }
        else if (Input.GetKeyUp(KeyCode.Tab))
        {
            canvasGroup.alpha = 0;
        }
    }
}
