using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	private CharacterMotor motor;

	// Use this for initialization
	void Start () {
		motor = transform.GetComponent<CharacterMotor>();
	}
	
	// Update is called once per frame
	void Update () {
		motor.inputMoveDirection = transform.forward;
		//Debug.Log ("moving");
	}

}
