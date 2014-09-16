using UnityEngine;
using System.Collections;

public class Puncher : MonoBehaviour {
	
	public float punchDelay;
	private float punchTime;

	// Use this for initialization
	void Start () {
		punchTime = punchDelay;
	}	
	
	// Update is called once per frame
	void Update () {

		if (punchTime != punchDelay) {
			punchTime -= Time.deltaTime;
			GetComponent<AnimationManager>().punch();
			if (punchTime <= 0) {
				punchTime = punchDelay;
				GetComponent<EnemyAI> ().endPunch();
			}
		}
	}

	public void punch () {
		punchTime = punchDelay - 0.01f;
	}
}
