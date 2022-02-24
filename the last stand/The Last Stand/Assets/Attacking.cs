using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attacking : MonoBehaviour
{
    public float cooldown;
    public float cooldownlength;
    public Transform attackarea;
    public float attackrange;
    public LayerMask enemies;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown <= 0)
        {
            if (Input.GetKey(KeyCode.J))
            {
                Collider2D[] KillEnemies = Physics2D.OverlapCircleAll(attackarea.position , attackrange,enemies);
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


    }
  void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(attackarea.position, attackrange);

    }
}
