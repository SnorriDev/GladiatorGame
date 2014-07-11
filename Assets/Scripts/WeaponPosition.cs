using UnityEngine;
using System.Collections;

public class WeaponPosition : MonoBehaviour {

	public Transform weapon;

	// Use this for initialization
	void Start () {
		Physics.IgnoreCollision (collider, transform.root.collider);
	}
	
	// Update is called once per frame
	void Update () {

		if (! transform.root.Find ("master").gameObject.activeInHierarchy) {
			transform.position = weapon.position;
			transform.rotation = weapon.rotation;
		}
		
	}
}
