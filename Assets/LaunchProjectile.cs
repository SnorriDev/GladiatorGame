using UnityEngine;
using System.Collections;

public class LaunchProjectile : MonoBehaviour {

	public Transform projectile;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			Instantiate(projectile, transform.position, transform.rotation);
		}
	}
}
