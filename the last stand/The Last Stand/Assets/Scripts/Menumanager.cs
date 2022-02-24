using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menumanager : MonoBehaviour
{
    public void LaunchHTP()
    {
        Debug.Log("going to the howtoplay›");
        SceneManager.LoadScene("htp");
        Debug.Log("went to how to play");
    }
//launches the How To Play menu screen

    public void LaunchGame()
    {
        Score.scoreval = 0;
        SceneManager.LoadScene("Game");
       
    }
//launches the game


    public void LaunchLeaderboards()
    {
        Debug.Log("going to lb");
        SceneManager.LoadScene("lb");

    }
//launches the Leaderboards



    public void LaunchMenu()
    {
        Debug.Log("going to the menu");
        SceneManager.LoadScene("Menu");

    }
//launches the Main Menu screen

    public void resetscores()
    {
        PlayerPrefs.SetInt("Highscore", 0);
        PlayerPrefs.SetString("thebest", null);
    }
//resets highscore values 



}

