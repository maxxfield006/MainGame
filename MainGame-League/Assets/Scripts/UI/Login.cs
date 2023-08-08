// Login Code: If the user has previously created a password, they are able to log in using the same credentials. This works using a text file that was previously created in the register script

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
    //Variables for the input fields and buttons that will be used
    public TMP_InputField usernameInput; // Input field for the username
    public TMP_InputField passwordInput;// Input field for the username
    public Button loginButton; // Button for when the user has added a username/password
    public TMP_Text loginMsg; // Text for displaying error messages etc

    [HideInInspector] // Just means it is hidden in inspector 
    public bool isLoggingIn = true; // Varible that is not relevant in either of the scripts I am handing in, but is relevant in other scripts

    ArrayList credentials; // an arraylist to store/ derive the credentails of the user

    // Start is called before the first frame update
    void Start()
    {
        // Add a listener to the loginButton to call the login method when clicked
        loginButton.onClick.AddListener(OnClickLogin);

        // Check if the credentials file exists (using the file path of where the game is located on the users computer)
        if (File.Exists(Application.dataPath + "/credentials.txt"))
        {
            // If the file exists, read all lines and store them in the "credentials" ArrayList
            credentials = new ArrayList(File.ReadAllLines(Application.dataPath + "/credentials.txt"));
        }
        else
        {
            Debug.Log("Credential file doesn't exist"); // Tells me if the file hasn't been created (not the user as there is a error for that later)
        }
    }

    // Main method that is called when the user clicks the login button
    void OnClickLogin()
    {
        bool isExists = false; //To check if the players username exists
        isLoggingIn = true; // again, relevant in another scirpt

        // Read all lines from the "credentials.txt" file and store them in the "credentials" ArrayList
        credentials = new ArrayList(File.ReadAllLines(Application.dataPath + "/credentials.txt"));

        // Iterate through each line in the credentials
        foreach (var i in credentials)
        { 
            // Check if the username and password match
            if (i.ToString().Substring(0, i.ToString().IndexOf(":")).Equals(usernameInput.text) &&  // To check if the username and password are the same as what the user added, I look at i as a string at substring position 0 to where the semi colon is (which is how the created usernames/passwords are stored
                i.ToString().Substring(i.ToString().IndexOf(":") + 1).Equals(passwordInput.text)) // does the same thing for the password accept it starts at substring position ":" + 1 so it will get the password and ignore the semi colon
            {
                isExists = true; // sets the isExist variable from before true
                break;
            }
        }

        if (isExists) // When is exists true, it means the user has entered the correct username/password and is able to login
        {
            // Display login message and wait for 3 seconds before loading the "Lobby" scene
            loginMsg.SetText("Logging in " + usernameInput.text); // sets the login text to a successful login message
            StartCoroutine(WaitForSeconds()); // waits for 3 seconds before loading next scene
            SceneManager.LoadScene("Lobby");
        }
        else
        {
            // Display incorrect username or password message (as that is the only error that can occur, rest are handled in the register script)
            loginMsg.SetText("Incorrect Username or Password");
        }
    }

    // returns timer in seconds
    IEnumerator WaitForSeconds()
    {
        // Coroutine to wait for 3 seconds
        yield return new WaitForSeconds(3);
    }
}