using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//delay level completion
//mission completion

public class Levels : MonoBehaviour {
	public int level;
	private bool objectivesComplete;
	public bool levelComplete;
	public bool missionComplete;
	public bool isPaused;
	public bool gameOver;
	public Transform enemy;

	public float halfHeight = 0.7f;
	public float width = 2f;

	public Transform player;

	private List<Transform> enemies;
	private int enemiesToSpawn;
	//private int enemiesDead;

	//TODO: maybe pick a node on the grid instead?

	private bool spawnEnemy() {
		Vector3 position = transform.position + new Vector3 (Random.Range (-10.0F, 10.0F), 0.0F, Random.Range (-10.0F, 10.0F));
		if (Physics.CheckCapsule (position + new Vector3 (0, halfHeight, 0), position - new Vector3 (0, halfHeight, 0), width)) {
			enemies.Add ((Transform)Instantiate (enemy, position, transform.rotation));
			return true;
		}
		return false;

	}


	public void generateLevel () {
		levelComplete = false;
		objectivesComplete = false;
		levelComplete = false;
		enemiesToSpawn = (level + 1) * 2 - 1;
		enemies = new List<Transform> ();
		bool enemySpawned;
		for (int abc = 0; abc < enemiesToSpawn; abc++) {
			enemySpawned = spawnEnemy();
			if (enemySpawned)
				enemies [abc].GetComponent<EnemyAI> ().damage += level;
			else
				abc--;
		}

		//Debug.Log ("Test1");
	}
	void Awake() {
		
		//Debug.Log ("Test0");
		player = GameObject.Find ("First Person Controller").transform;
		gameOver = false;
		Screen.showCursor = false; 

		generateLevel ();

	}

	void endGame () {
		Debug.Log ("Game ova bitch");
		gameOver = true;
		Time.timeScale = 0;
		//TODO: red screen 
	}

	void Update () {
		if (player.GetComponent<HealthManager> ().isDead() && !gameOver) {
			endGame ();
			gameOver = true;
			return;
		}

		if (isPaused) {
			return;
		}

		objectivesComplete = true;

		for (int i = 0; i < enemies.Count; i++) {
			objectivesComplete &= enemies [i].GetComponent<HealthManager> ().isDead ();
		}

		if (objectivesComplete) {
			levelComplete = true;
			//Debug.Log ("AllDead");
			StartCoroutine(changeLevel ());
			isPaused = true;
		}

		/*if (levelComplete) {
			for (int i = 0; i < enemies.Count; i++) {
				Destroy (enemies [i].gameObject);
			}
			enemies = new List<Transform>();
			level ++;
			generateLevel ();
			Debug.Log ("Test33333333333333333");
			levelComplete = false;
			allDead = false;
		}*/

	}


	public IEnumerator changeLevel () {
		//print(Time.time);
		yield return new WaitForSeconds(5);
		//print(Time.time);
		
		for (int i = 0; i < enemies.Count; i++) {
			Destroy (enemies [i].gameObject);
		}
		enemies = new List<Transform>();
		level ++;
		generateLevel ();
		//Debug.Log ("Test33333333333333333");
		//levelComplete = false;
		objectivesComplete = false;
		isPaused = false;
		}

}
