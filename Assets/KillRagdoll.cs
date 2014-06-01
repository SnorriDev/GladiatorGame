using UnityEngine;
using System.Collections;

public class KillRagdoll : MonoBehaviour {

	// Use this for initialization
	void Start() {
		//kill<BoxCollider> ();
		//setRagdoll (true);
		activateRecursively(transform.Find("ragdoll"), false);
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.Z)) {
			Debug.Log ("dead");
			GetComponent<CharacterController>().detectCollisions = false;
			activateRecursively(transform.Find ("ragdoll"), true);
			setRagdoll(true);
		}
	}

	private void kill<E>() where E : Collider {
		foreach (E r in transform.GetComponentsInChildren<E>()) {
			Debug.Log(r);
			((Collider) r).isTrigger = true;
		}

	}

	private void setRagdoll(bool flag) {
		foreach (Rigidbody r in transform.GetComponentsInChildren<Rigidbody>()) {
			r.isKinematic = ! flag;
		}
	}

	private void activateRecursively(Transform trans, bool flag) {
		trans.gameObject.SetActive(flag);
		foreach (Transform t in trans) {
			activateRecursively(t, flag);
		}
	}
	//the

}
