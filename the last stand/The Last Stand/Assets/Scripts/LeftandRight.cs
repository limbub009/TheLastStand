using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftandRight : MonoBehaviour
{
    public Rigidbody2D rb;
    public float movespeed;
    public float tapwindow;
    private float taptime;
    //variables declared 


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movespeed = 7f;
        tapwindow = 0.5f;
        taptime = 0;
        //values given to variables 

    }

    // Update is called once per frame
    void Update()
    {
    
    if (Input.GetKey(KeyCode.D)) //if D is held down or pressed
            {
            transform.localScale = new Vector2(1f, 1f);
            //will face the player to the right
            rb.velocity = new Vector2(movespeed, rb.velocity.y);
            //character will move to the left at a fixed velocity and same y position
        }
    if (Input.GetKeyDown(KeyCode.D)) //if D is pressed again
            {
            if ((Time.time - taptime) < tapwindow) //if D is pressed again between the time window of 0.5 seconds 
                {
                    rb.position = new Vector2(rb.position.x + 3, rb.position.y); 
                    //character will dash to the right but remain in the same y position.
                }
                taptime = Time.time; 
                //time window reset (dash reset) 
            }


    if (Input.GetKey(KeyCode.A)) //if A is held down or pressed 
            { 
            transform.localScale = new Vector2(-1f, 1f);
            //will face the player to the left
           
            rb.velocity = new Vector2(-movespeed, rb.velocity.y); 
            //character will move to the left at a fixed velocity and same y position 
        }
    if (Input.GetKeyDown(KeyCode.A)) //if A is pressed again
            {
              if ((Time.time - taptime) < tapwindow) //If a is pressed again between the time window of 0.5 seconds
                {
                    rb.position = new Vector2(rb.position.x - 3, rb.position.y); //character will dash to the left.
                }
                taptime = Time.time; //time window reset (dash reset)
            }

        if (Input.GetKeyDown(KeyCode.H))

        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            //when H is pressed it will flip the character upright.
        }
      


    }
    }

//rb.AddForce(Vector2.left * movespeed);
//rb.AddForce(Vector2.right * movespeed);
//movespeed = 150f;

//if (Input.GetKeyDown(KeyCode.D) && a == 1)
// Debug.Log("im dashing");
// {
//  rb.position = new Vector2(rb.position.x + 2, rb.position.y);
//a = 2;

// }
//transform.localScale = new Vector2(-1f, 1f);
//transform.localScale = new Vector2(1f, 1f);