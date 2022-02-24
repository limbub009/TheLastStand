using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class usernamemanager : MonoBehaviour
{
    public static string username;
    //global variable
    public InputField userinput;
    public Text output;
    public bool valid;
    //variables delcared



    void Update()
    {
        getusername();
        //function get username


        if (username.Length >= 12)
        {
            output.text = "enter a name that is less than 12 characters";
        }
        //checks if username is more than 12 charachters

        if (username.Length <= 3)
        {
            output.text = "enter a name that is longer than 3 characters";
        }
        //checks if usename is less than 3 characters

        if (username.Length <= 12 & username.Length >= 3)
        {
            output.text = "thats a good name!";
        }
        //if username is between 12 and 3 chracters long then it will accept the username.

    }


    public void getusername()

    {
        username = userinput.text;
        Debug.Log("username has been recieved");
        //username is recevied from the textbox. 

    }
}

       




