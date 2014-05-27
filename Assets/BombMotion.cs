using UnityEngine;
using System.Collections;

public class BombMotion : MonoBehaviour {

	public float speed;

	void Start () {
		rigidbody.AddForce (transform.forward * speed);
	}

}
