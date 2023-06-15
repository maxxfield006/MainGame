using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Login : MonoBehaviour
{

    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public Button loginButton;
    public TMP_Text loginMsg;

    [HideInInspector]
    public bool isLoggingIn = true;


    ArrayList credentials;

    // Start is called before the first frame update
    void Start()
    {
        loginButton.onClick.AddListener(login);

        if (File.Exists(Application.dataPath + "/credentials.txt"))
        {
            credentials = new ArrayList(File.ReadAllLines(Application.dataPath + "/credentials.txt"));
        }
        else
        {
            Debug.Log("Credential file doesn't exist");
        }

    }



    
    void login()
    {
        bool isExists = false;
        isLoggingIn = true;

        credentials = new ArrayList(File.ReadAllLines(Application.dataPath + "/credentials.txt"));

        foreach (var i in credentials)
        {
            string line = i.ToString();

            if (i.ToString().Substring(0, i.ToString().IndexOf(":")).Equals(usernameInput.text) &&
                i.ToString().Substring(i.ToString().IndexOf(":") + 1).Equals(passwordInput.text))
            {
                isExists = true;
                break;
            }
        }

        if (isExists)
        {
            loginMsg.SetText("Logging in " + usernameInput.text);
            StartCoroutine(waitForSeconds());
            SceneManager.LoadScene("ConnectToLobby");

        }
        else
        {
            loginMsg.SetText("Incorrect Username or Password");
        }
    }
    IEnumerator waitForSeconds()
    {
        yield return new WaitForSeconds(3);
    }
}