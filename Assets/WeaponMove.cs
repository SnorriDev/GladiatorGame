using UnityEngine;
using System.Collections;

public class WeaponMove : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		transform.localPosition = Vector3.Slerp (transform.localPosition, new Vector3 (1, 1, 0), .01f);
	}
}
