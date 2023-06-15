using System.Collections;
using System.Collections.Generic;
using System.Security;
using System.Xml;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    public GameObject character;
    public GameObject cam;
    public Transform blueSpawn;

    public GameObject roundBackground;
    public GameObject botHud;
    public GameObject topHud;
    public GameObject round1;
    public GameObject items1;

    public MrHanStats stats;
    public MHAbilities abilities;

    public NavMeshAgent champ;
    void Start()
    {
        StartCoroutine(hideOverLays());
        //character.GetComponent<PlayerController>().enabled = false;
        //character.GetComponent<MHAbilities>().enabled = false;
    }


    void StartGame()
    {
        roundBackground.SetActive(false);
        character.GetComponent<PlayerController>().enabled = true;
        character.GetComponent<MHAbilities>().enabled = true;
        botHud.SetActive(true);
        
    }

    IEnumerator hideOverLays()
    {
        round1.SetActive(true);
        botHud.SetActive(false);
        items1.SetActive(false);
        yield return new WaitForSeconds(3);
        round1.SetActive(false);
        items1.SetActive(true);
    }

    public void onSwordButtonClicked()
    {
        StartGame();
        stats.attackDmg += 50;
        stats.attackTime -= 0.1f;
        abilities.initialDmg = stats.attackDmg;
    }
    public void onCrystalButtonClicked()
    {
        StartGame();
        stats.health += 200;
        champ.speed += 0.1f;
        abilities.initialDmg = 60;
    }

    public void onDaggerButtonClicked()
    {
        StartGame();
        stats.attackSpeed = 1.25f;
        champ.speed += 0.5f;
        abilities.initialDmg = 60;
    }



}
