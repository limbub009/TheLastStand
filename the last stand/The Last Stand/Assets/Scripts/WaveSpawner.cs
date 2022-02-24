using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour {

	public enum SpawnState { SPAWNING, WAITING, COUNTING };
    //states declared
	[System.Serializable]
    //allows coroutines in Unity
	public class Wave
	{
		public string name;
		public Transform enemy;
		public int count;
		public float rate;
        //object wave created
	}
	public Wave[] waves;
    //array of wave objects created
	private int nextWave = 0;
	public int NextWave
	{
		get { return nextWave + 1; }
	}
    //this variable value nextwave + 1
	public Transform[] spawnPoints;
    //variables for spawn points created
    public float timeBetweenWaves = 5f;
    //the time the player has to rest befor the next wave starts
    private float waveCountdown;
    //the countdown the wave gives
	public float WaveCountdown
	{
		get { return waveCountdown; }
	}
	private float searchCountdown = 1f;
    //searchcountdown variable declared
	private SpawnState state = SpawnState.COUNTING;
	public SpawnState State
	{
		get { return state; }
	}





	void Start()
	{
		if (spawnPoints.Length == 0)
		{
			Debug.LogError("there are no spawnpoints");
		}
        //checks if there are spawn points to spawn enemies. 

		waveCountdown = timeBetweenWaves;
        //wave countdown is declared
	}









	void Update()
	{
		if (state == SpawnState.WAITING) //if the state is waiting (waiting for the player to finish the wave)
		{
			if (!EnemyIsAlive()) //if there are no more enemies on the map then
			{
				WaveCompleted();
                //run wavecompleted function
			}
			else 
			{
				return;
                //do nothing
			}
		}

		if (waveCountdown <= 0)
            //if wavecountdown has finished
		{
			if (state != SpawnState.SPAWNING)
                //if the state is not equal to spawnning
			{
				StartCoroutine( SpawnWave ( waves[nextWave] ) );
                //run coroutine with the next wave in the array.
			}
		}
		else //if the coutndown hasnt finished
		{
			waveCountdown -= Time.deltaTime;
            //keep counting down 
		}
	}











	void WaveCompleted()
        //function that handles the game when the wave is completed
	{
		Debug.Log("Wave Completed!");

		state = SpawnState.COUNTING;
		waveCountdown = timeBetweenWaves;
        //starts giving the player time to rest.

		if (nextWave + 1 > waves.Length - 1)
            //if next wave is bigger than the number of waves in the array
		{
			nextWave = 0;
			Debug.Log("looping game");
            //there are no more waves remaining
            //the game will loop starting from wave 0 
		}
		else //if not
		{
			nextWave++;
            // it goes onto the next wave in the array
		}
	}







	bool EnemyIsAlive()
        //function that checks if there are any enemies alive from the previous wave
	{
		searchCountdown -= Time.deltaTime;
        //countdown decrements 
		if (searchCountdown <= 0f)
            //if the countdown reaches 0
		{
			searchCountdown = 1f;
            //countdown is increased, gives more time to search for the enemy.
			if (GameObject.FindGameObjectWithTag("badguy") == null)
            //if the game finds an enemy 
			{
				return false;
                // it will return false 
			}
		}
		return true;
        //otherwise it will return true 
	}













	IEnumerator SpawnWave(Wave _wave)
	{
		Debug.Log("Spawning Wave: " + _wave.name);
        //broadcasts what wave the player is on
		state = SpawnState.SPAWNING;
        //state is changed to spawnning

		for (int i = 0; i < _wave.count; i++) 
        //loop that spawns the enemy in the wave object
		{
			SpawnEnemy(_wave.enemy);
            //runs another routine with the enemy with the wave object
			yield return new WaitForSeconds( 1f/_wave.rate );
            //uses the rate from the wave object to increase or decrease the rate of spawnning
		}

		state = SpawnState.WAITING;
       
		yield break;
        //after spawnning it changes the game state to waiting 
    }









	void SpawnEnemy(Transform _enemy)
        //routine that spawns enemies
	{
		Debug.Log("Spawning Enemy: " + _enemy.name);

		Transform _sp = spawnPoints[ Random.Range (0, spawnPoints.Length) ];
		Instantiate(_enemy, _sp.position, _sp.rotation);
        //at the spawn point it spawns new enemies every time it called. 
        //the point at where it spawns is random
	}

}
