using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wiritng : MonoBehaviour
{
    public class Enemy
    {
        public int health;
        public float speed;
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
        Lanky.points = 3;
        Lanky.speed = 5;
        Lanky.target = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>();
        //new enemy object inherits attributes 
        //attribuites given values
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, Lanky.target.position, Lanky.speed * Time.deltaTime);
        //enemy locates the player and follows the player
        //follows until it is within range of the player 
        //or it cannot attack the player



        //cooldown -= Time.deltaTime;
        //cooldown time is reduced }
    }
}


