using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingMove : MonoBehaviour
{
    public float cooldown;
    public float cooldownlength;
    public Transform attackarea;
    public float attackrange;
    public LayerMask enemies;
    public int damage;
    public Animator ani;
    public bool attacking;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (cooldown <= 0)
        {
            if (Input.GetKey(KeyCode.J))
            {
                ani.Play("attacking");
                Debug.Log("animation");
                Collider2D[] KillEnemies = Physics2D.OverlapCircleAll(attackarea.position, attackrange, enemies);
                for (int i = 0; i < KillEnemies.Length; i++)
                {
                    KillEnemies[i].GetComponent<badguy>().hit(damage);
                }

            }
            cooldown = cooldownlength;



        }
        else

        {

            cooldown -= Time.deltaTime;

        }


        //if (attacking == false)
        // {

        // }


    }

 
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(attackarea.position, attackrange);

    }
}
