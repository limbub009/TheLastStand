using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Hleath : MonoBehaviour
{
    // Start is called before the first frame update

    public static int health;
    //global variable health
    public int HP;
    public int numofhearts;
    public Image[] hearts;
    //array of images
    public Sprite fullheart;
    public Sprite emptyheart;
    //variables declared

   
   void Start()
    {
        health = 10;
        Debug.Log("health = 10");
        //health set to 10 as the game starts
    }

    // Update is called once per frame
    void Update()
    { 
        if (health <= 0) // if health = 0
        {
            Destroy(gameObject);
            //player will die
        }


        for (int i = 0; i < hearts.Length; i++)//for loop
        {

            if (i < health) //if the counter is less than health
            {
                hearts[i].sprite = fullheart;
                //it will display a full heart. As player stll has HP remaining.
            }
            else //if the counter is more than health
                //player has lost health
            {
                hearts[i].sprite = emptyheart;
                //it will display a empty heart. As player has lost HP.
            }

            if (i < numofhearts)
            {
                hearts[i].enabled = true;
                //if the counter is less than number of hearts then it will display a heart
                //the code has not reached the maxiumum HP.
                //it will display the hearts as it checks if it has reached max HP
            }
            else
            {
                hearts[i].enabled = false;
                //if the counter is larger than the number of hearts it shows that the counter has reached max hp. 
                //Therefore the rest of the hearts are disbaled and not displayed.
            }
        }
    }
}

//SceneManager.LoadScene("gameover");
            //gameover screen is loaded.
           // Debug.Log("loading scene");