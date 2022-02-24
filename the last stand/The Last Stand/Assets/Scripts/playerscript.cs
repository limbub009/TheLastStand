using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerscript : MonoBehaviour {
    public float jumpforce;
    public Rigidbody2D rb;
    public bool grounded;
    public int jumps;
    //variables for jumping

    public float movespeed;
    public float tapwindow;
    private float taptime;
    //variables for dashing & moving

    public float cooldown;
    public float cooldownlength;
    public Transform attackarea;
    public float attackrange;
    public LayerMask badguy;
    public int damage;
    public Animator ani;
    public bool attacking;
    //variables for attacking

   

    void Start()
    {
        grounded = false;
        rb = GetComponent<Rigidbody2D>();
        jumps = 2; ; 
        //variables for jumping given values.

        movespeed = 7f;
        tapwindow = 0.5f;
        taptime = 0;
        //variables for dashing & moving given values

        ani = GetComponent<Animator>();
        //variables for attacking given values

       //healthbar = GetComponent<Image>();
        //variables for healthbar script.

    }


    void Update()
    {

        //Jumping   
        if (Input.GetKeyDown(KeyCode.W) && jumps > 0) //if jumps is bigger than 0 and W has been pressed launch jump. 
        {
            rb.velocity = Vector2.up * jumpforce;
            jumps--;  //number of jumps reduced. 
        }

        //Left Right
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


        //Flip Upright
        if (Input.GetKeyDown(KeyCode.H))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            //when H is pressed it will flip the character upright.
        }


        //Attacking

        if (cooldown <= 0) //when cooldown reaches 0 or less than 0
        {
            if (Input.GetKey(KeyCode.J)) //if the player presses J 
            {
                ani.Play("attacking");
                //play attack animation
                Debug.Log("animation");
                Collider2D[] KillEnemies = Physics2D.OverlapCircleAll(attackarea.position, attackrange, badguy); 
                //creates the attack radius where enemies are damaged
                for (int i = 0; i < KillEnemies.Length; i++)
                {
                    KillEnemies[i].GetComponent<badguy>().hit(damage);
                    //hit function is launched, enemies are damaged by the "damage variable"
                    Debug.Log("HITTING ENEMIES");
                }

            }
            cooldown = cooldownlength;
            //cooldown is reset 
        }
        else

        {
            cooldown -= Time.deltaTime;
            //cooldown time is reduced 
        }
    }







    //other 

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(attackarea.position, attackrange);
        //sets up invisible attack radius where enemies are damaged
    }


    void OnTriggerEnter2D() // when the player and the ground touch
    {
        grounded = true;
        jumps = 2;  
        //number of jumps reset after touching the ground. 
    }


    void OnTriggerExit2D() // when the player and the ground are not touching
    {
        grounded = false; 
    }
}
