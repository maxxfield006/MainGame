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
    public Button nameButton;

    public TMP_Text errorMsg;

    private string[] nameColor = { "Red", "Orange", "Yellow", "Lime", "Green", "Blue", "Purple", "Black", "White", "Teal", "Grey", "Violet", "Amber", "Crimson", "Bronze", "Silver", "Gold", "Emerald", "Cherry", "Peach"};
    private string[] nameAnimal = { "Cat", "Pig", "Owl", "Ape", "Cow", "Rat", "Ant", "Elk", "Bat", "Yak", "Gnu", "Eel", "Emu", "Ram", "Dzo", "Dog", "Bee", "Fox", "Hen", "Koi"};


    ArrayList credentials;

    void Start()
    {
        errorMsg = GameObject.Find("ErrorMSG").GetComponent<TMP_Text>();

        registerButton.onClick.AddListener(writeStuffToFile);
        nameButton.onClick.AddListener(generateRandomName);

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
        int numCharCount = usernameInput.text.Length;

        foreach (char c in usernameInput.text)
        {
            if (char.IsDigit(c))
            {
                numCount++;
            }
            if (char.IsLetterOrDigit(c))
            {
                numCharCount--;
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
        else if (numCharCount > 0)
        {
            errorMsg.SetText("Username " + usernameInput.text + "  contains special characters (eg @#!$");
        }
        
        else
        {
            credentials.Add(usernameInput.text + ":" + passwordInput.text);
            File.WriteAllLines(Application.dataPath + "/credentials.txt", (String[])credentials.ToArray(typeof(string)));
            errorMsg.SetText("Account Registered");
        }
    }

    void generateRandomName()
    {
        int randomNum = UnityEngine.Random.Range(0, 21);
        int randomNum1 = UnityEngine.Random.Range(0, 21);

        string randomColor = nameColor[randomNum];
        string randomAnimal = nameAnimal[randomNum1];
        string finalName = randomColor + randomAnimal;

        if (finalName.Length < 9)
        {
            int randomInt = UnityEngine.Random.Range(0, 99);
            finalName += randomInt;
        }

        usernameInput.SetTextWithoutNotify(finalName);
    }


}