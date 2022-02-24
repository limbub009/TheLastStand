using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wavespawner : MonoBehaviour
{
    // Start is called before the first frame update

    public enum Spawnstate { Spawning, Waiting, Counting }
    [System.Serializable]
    //allows to change the values of the variables of the class.
    //allows the vairable to be edited in unity.

    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }
    public Wave[] waves;
    private int nextwave = 0;
    public float timebtwwaves = 5f;
    public float wavecountdown;
    public Spawnstate state = Spawnstate.Counting;

    private float searchtime = 1f;


    void Start()
    {
        wavecountdown = timebtwwaves;

    }

    // Update is called once per frame
    void Update()
    {
        if (state == Spawnstate.Waiting)
        {
            if (EnemyIsAlive() == true)
            {
                //begin the next wave
                //let player know
                //poitns awarded
                Debug.Log("wave completed");
                return;
            }
            else
            {
                return;
            }
            //check if enemies are alive
        }
        if (wavecountdown <= 0)
        {
            Debug.Log("wave completed");
            if (state != Spawnstate.Spawning)
            {
                StartCoroutine(SpawnWave(waves[nextwave]));

                //start spawning wave
            }
            else
            {
                wavecountdown -= Time.deltaTime;
            }
        }
    }



    bool EnemyIsAlive()
    {
        searchtime -= Time.deltaTime;
        if (searchtime <= 0f)
        {
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
            //didint return true;
        }
        return true; 
    }      
    //after spawning it goes to waiting
    //whilw waiting it checks if enemies are alive




    IEnumerator SpawnWave(Wave _wave)
    {
        state = Spawnstate.Spawning;

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f/_wave.rate);

              
        }
        //spawn

        state = Spawnstate.Waiting;


        yield break;
    }




    void SpawnEnemy(Transform _enemy)
    {
        Debug.Log("spawnning enemy");
        Instantiate(_enemy, transform.position, transform.rotation);
    }

    //allows the system to wait before the next wave.

}
