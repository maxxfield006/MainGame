using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadinScreen : MonoBehaviour
{
    public GameObject background;
    public GameObject start;
    public GameObject login;
    public GameObject register;
     
    void Start()
    {
        login.SetActive(false);
        register.SetActive(false);
    }

    public void OnStartButtonClick()
    {
        login.SetActive(true);
        background.SetActive(false);
        start.SetActive(false);
    }
    public void OnRegisterBtnClick()
    {
        login.SetActive(false);
        register.SetActive(true);
    }

}

