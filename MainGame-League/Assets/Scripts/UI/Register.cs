using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Linq;
using UnityEditorInternal;

public class Register : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public Button registerButton;

    public TMP_Text errorMsg;


    ArrayList credentials;

    void Start()
    {
        errorMsg = GameObject.Find("ErrorMSG").GetComponent<TMP_Text>();

        registerButton.onClick.AddListener(writeStuffToFile);

        if (File.Exists(Application.dataPath + "/credentials.txt"))
        {
            credentials = new ArrayList(File.ReadAllLines(Application.dataPath + "/credentials.txt"));
        }
        else
        {
            File.WriteAllText(Application.dataPath + "/credentials.txt", "");
        }

    }


    void writeStuffToFile()
    {
        int numCount = 0;

        foreach (char c in usernameInput.text)
        {
            if (char.IsDigit(c))
            {
                numCount++;
            }
        }

        bool isExists = false;

        credentials = new ArrayList(File.ReadAllLines(Application.dataPath + "/credentials.txt"));
        foreach (var i in credentials)
        {
            if (i.ToString().Contains(usernameInput.text))
            {
                isExists = true;
                break;
            }

        }

        if (usernameInput.text.Count() > 10 || usernameInput.text.Count() <= 2)
        {
            errorMsg.SetText("Username " + usernameInput.text + " too long/short");
        }

        else if (numCount >= 5)
        {
            errorMsg.SetText("Username " + usernameInput.text + " contains more then 5 numbers");
        }

        else if (isExists)
        {
            errorMsg.SetText("Username " + usernameInput.text + " already exists");
        }
        
        else
        {
            credentials.Add(usernameInput.text + ":" + passwordInput.text);
            File.WriteAllLines(Application.dataPath + "/credentials.txt", (String[])credentials.ToArray(typeof(string)));
            errorMsg.SetText("Account Registered");
        }
    }


}