using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Levels : MonoBehaviour {
	public int level;
	private bool allDead;
	public bool levelComplete;
	public Transform enemy;

	private List<Transform> enemies;
	private int enemiesToSpawn;
	//private int enemiesDead;

	public void generateLevel () {
		Debug.Log ("HIIII");
		levelComplete = false;
		allDead = false;
		levelComplete = false;
		enemiesToSpawn = (level + 1) * 2 - 1;
		enemies = new List<Transform> ();
		for (int abc = 0; abc < enemiesToSpawn; abc++) {
			enemies.Add ((Transform) Instantiate(enemy, (transform.position + new Vector3(Random.Range(-10.0F,10.0F), 0.0F, Random.Range(-10.0F,10.0F))), transform.rotation));
			Debug.Log ("enemy spawned");
		}

		Debug.Log ("Test1");
	}
	void Start() {
		generateLevel ();
		Debug.Log ("Test0");
	}

	void Update () {

		allDead = true;

		for (int i = 0; i < enemies.Count; i++) {
			allDead &= enemies [i].GetComponent<HealthManager> ().isDead ();
		}

		if (allDead) {
			levelComplete = true;
			Debug.Log ("AllDead");
		}

		if (levelComplete) {
			for (int i = 0; i < enemies.Count; i++) {
				Destroy (enemies [i].gameObject);
			}
			enemies = new List<Transform>();
			level ++;
			generateLevel ();
			Debug.Log ("Test33333333333333333");
			levelComplete = false;
			allDead = false;
		}

	}
}
