using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class saveNames : MonoBehaviour
{
    public static saveNames playerName;
    public string userName;

    Register registerScript;
    Login loginScript;
    private void Awake()
    {
        if (playerName != null)
        {
            playerName = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (userName != registerScript.usernameInput.text && !loginScript.isLoggingIn)
        {
            userName = registerScript.usernameInput.text;
            Debug.Log(userName);
        }
        else if (userName != loginScript.usernameInput.text && loginScript.isLoggingIn)
        {
            userName = loginScript.usernameInput.text;
            Debug.Log(userName);
        }
    }
}
