using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


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
        background.SetActive(false);
        start.SetActive(false);
        login.SetActive(true);
    }
    public void OnRegisterBtnClick()
    {
        login.SetActive(false);
        register.SetActive(true);
    }

}

