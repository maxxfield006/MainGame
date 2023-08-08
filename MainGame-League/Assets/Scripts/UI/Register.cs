//Registration code: This code allows the user to create a user name which will then be added to a text file that will be accessed in the login script 

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Linq;
using System.Diagnostics;

public class Register : MonoBehaviour
{
    // Variables for the input fields and buttons on the register tab
    public TMP_InputField usernameInput; // The input field that gets the players username input
    public TMP_InputField passwordInput;// The input field that gets the players password input
    public Button registerButton;// The button that allows the player to register
    public Button nameButton;// The button that allows the player to generate a random name

    // Variable for error message
    public TMP_Text errorMsg;

    // Two string arrays for the generated names
    private string[] nameColor = { "Red", "Orange", "Yellow", "Lime", "Green", "Blue", "Purple", "Black", "White", "Teal", "Grey", "Violet", "Amber", "Crimson", "Bronze", "Silver", "Gold", "Emerald", "Cherry", "Peach" };
    private string[] nameAnimal = { "Cat", "Pig", "Owl", "Ape", "Cow", "Rat", "Ant", "Elk", "Bat", "Yak", "Gnu", "Eel", "Emu", "Ram", "Dzo", "Dog", "Bee", "Fox", "Hen", "Koi" };

    // An ArrayList to store the users credentials, aswell as put them on a text file
    ArrayList credentials;

    // Runs code at the start of the game
    void Start()
    {
        // Checking if there is a text file in the specified path named "credentials"
        if (File.Exists(Application.dataPath + "/credentials.txt"))
        {
            // If the file exists, read all lines and store them in the "credentials" ArrayList
            credentials = new ArrayList(File.ReadAllLines(Application.dataPath + "/credentials.txt"));
        }
        else
        {
            // If the file doesn't exist, create an empty file named "credentials" in the specified path
            File.WriteAllText(Application.dataPath + "/credentials.txt", "");
        }
    }

    // Main section of code that is called wqhen the user clicks the register button
    public void WriteStuffToFile()
    {
        // Variables to store counts of numbers and characters in the username input
        int numCount = 0;
        int numCharCount = usernameInput.text.Length;

        // Lengths of the password and username input
        int passwordLength = passwordInput.text.Length;
        int usernameLength = usernameInput.text.Length;

        // Counting the number of digits and non-alphanumeric characters in the username input
        foreach (char c in usernameInput.text)
        {
            if (char.IsDigit(c)) // checks if the character c is a digit (goes through entire username)
            {
                numCount++; // adds one to numCount
            }
            if (char.IsLetterOrDigit(c))// checks if the character c is a digit (goes through entire username)
            {
                numCharCount--;  // takes one off numCharCount
            }
        }

        bool isExists = false; // Used later in code to check if the username already exists

        // Reading all lines from the "credentials.txt" file and storing them in the "credentials" ArrayList (used for checking if the username already exists in the text file)
        credentials = new ArrayList(File.ReadAllLines(Application.dataPath + "/credentials.txt"));

        // Checking if the username already exists in the credentials, if it does sets the isExists variable from earlier as true
        foreach (var i in credentials)
        {
            if (i.ToString().Contains(usernameInput.text)) // checks if index i in credentials contains the new username
            {
                isExists = true;
                break;
            }
        }

        // Validating username and password inputs
        if (usernameInput.text.Count() > 10 || usernameInput.text.Count() <= 2) // uses the count method to count the number of characters in the new username
        {
            errorMsg.SetText("Username " + usernameInput.text + " is too long/short");
        }
        else if (passwordLength < 1) // uses the password length variable from earlier to make sure the user added a password
        {
            errorMsg.SetText("You must add a password");
        }
        else if (numCount >= 5) //making sure the user hasn't added more then 5 numbers in their name (doesn't apply to password)
        {
            errorMsg.SetText("Username " + usernameInput.text + " contains more than 5 numbers");
        }
        else if (isExists) //makes sure the username doesn't already exist using the isExists variable from earlier
        {
            errorMsg.SetText("Username " + usernameInput.text + " already exists");
        }
        else if (numCharCount > 0) //makes sure there aren't any special characters like "@#!"
        {
            errorMsg.SetText("Username " + usernameInput.text + " contains special characters (e.g., @#!$)");
        }
        else // if all the conditions are met it creates the username and stores it in the text file
        {
            // Adding the username and password to the credentials ArrayList
            credentials.Add(usernameInput.text + ":" + passwordInput.text);

            // Writing all lines from the credentials ArrayList to the "credentials.txt" file
            File.WriteAllLines(Application.dataPath + "/credentials.txt", (String[])credentials.ToArray(typeof(string)));

            errorMsg.SetText("Account Registered");

            // Waiting for 3 seconds before loading the "Lobby" scene
            StartCoroutine(WaitForSeconds());
            SceneManager.LoadScene("Lobby");
        }
    }

    //On the generate name button this method will be called and it will return a string of a new randomized name
    public void GenerateRandomName()
    {
        // Generating random indices for the nameColor and nameAnimal arrays
        int randomNum = UnityEngine.Random.Range(0, 21);
        int randomNum1 = UnityEngine.Random.Range(0, 21);

        // Getting a random color and animal from the arrays
        string randomColor = nameColor[randomNum];
        string randomAnimal = nameAnimal[randomNum1];
        string finalName = randomColor + randomAnimal; // creating the final name from the two random names

        // Adding a random two-digit number if the generated name is less than 9 characters
        if (finalName.Length < 9)
        {
            int randomInt = UnityEngine.Random.Range(0, 99);
            finalName += randomInt;
        }

        // Setting the generated name as the username input text
        usernameInput.SetTextWithoutNotify(finalName);
    }

    // returns a timer in seconds that will wait for 3 seconds
    IEnumerator WaitForSeconds()
    {
        // Coroutine to wait for 3 seconds
        yield return new WaitForSeconds(3);
    }
}