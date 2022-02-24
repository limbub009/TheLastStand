using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class badguy : MonoBehaviour
{
    public class Enemy
    {
        public int health;
        public float speed;
        public float distance;
        public int points;
        public Transform target;
        //attributes of the class
    }
    //enemy class declared


    Enemy Lanky = new Enemy();
    //new object based on enemy class created
   


    // Start is called before the first frame update
    void Start()
    {
        Lanky.health = 36;
        Lanky.distance = 1;
        Lanky.points = 3;
        Lanky.speed = 5;
        Lanky.target = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>();
        //new enemy object inherits attributes 
        //attribuites  given values
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, Lanky.target.position) > Lanky.distance) 
        //if the player is further away than the stopping distnace
        {
            transform.position = Vector2.MoveTowards(transform.position, Lanky.target.position, Lanky.speed * Time.deltaTime);
            //enemy locates the player and follows the player
            //follows until it is within range of the player 
            //or it cannot attack the player

        }


        if (Lanky.health <= 0) //when enemy health is below 0
        {
            Destroy(gameObject);
            Score.scoreval = Score.scoreval + 10;
            //then enemy is destroyed and points are awarded to the player.
        }

            
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        Hleath.health -= 1;
        Debug.Log("die player");
        //if the player collides with the enemy 
        //he will take damage.
    }

    public void hit(int damage) 
        // when the player launches the attack it launches the hit function. 
        // the hit function is used here to damage the enemy
    {
        Lanky.health -= damage;
        //enemy is damaged by the player's damage variable
        Debug.Log("i took damage");
    }

}
