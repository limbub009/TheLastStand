
using UnityEngine;
using UnityEngine.UI;

public class dice : MonoBehaviour
{
    
    public Text score;
    public Text highscore;
    public Text best;
    public Text playername;
    //variables declared
    //all variables are UI text


    void Start()
    {
        highscore.text = "Highscore: " + PlayerPrefs.GetInt("Highscore", 0).ToString();
        //externally stored highscore is loaded and is displayed on the UI of the leaderboard screen.
        best.text = "The Best: " + PlayerPrefs.GetString("thebest");
        //externaly stored username is loaded and is displayed on the UI of the leaderboard screen.

    }


    //updates every frame
    void Update()
    {
        int hs = Score.scoreval;
        //integer that stores the current score
        score.text = "Your score: " + hs.ToString();
        //displays your current score
        playername.text = usernamemanager.username;
        //displays your current username

        if (hs > PlayerPrefs.GetInt("Highscore",0)) 
        //if the current score is higher than the highscore
        {
            PlayerPrefs.SetInt("Highscore", hs);
            highscore.text = "Highscore: " + hs.ToString();
            //externally stored score is replaced
            //new highscore is displyaed

            PlayerPrefs.SetString("thebest", usernamemanager.username);
            best.text = usernamemanager.username;
            //externally stored username is replaced
            //new username is displayed
        }

    }
   
}




