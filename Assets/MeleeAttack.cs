using UnityEngine;
using System.Collections;

public class MeleeAttack : MonoBehaviour {


	private Vector3 newPosition;
	public Vector3 positionA;
	public Vector3 positionB;

	public float errorBound;
	public float swingSpeed;

	private bool isStill () {
		return (transform.localPosition - newPosition).magnitude < errorBound;
	}

	private bool isIdle() {
		return (transform.localPosition - positionA).magnitude < errorBound;
	}

	void Start () {
		transform.localPosition = positionA;
		newPosition = positionA;
		}

	void Update () {



		if (Input.GetKeyDown (KeyCode.P) && isIdle()) {
			newPosition = positionB;
		}
		if (isStill () && ! isIdle ()) {
			newPosition = positionA;
		}

		transform.localPosition = Vector3.Lerp(transform.localPosition, newPosition, swingSpeed * Time.deltaTime);
	}
}

//look up the Lerp and Slerp functions
