using UnityEngine;
using System.Collections;

public class KillRagdoll : MonoBehaviour {

	// Use this for initialization
	void Start() {
		activateRecursively (transform.Find ("master"), false);
	}

	public void kill() {
		GetComponent<CharacterController>().enabled = false;
		GetComponent<AnimationManager>().enabled = false;
		GetComponent<Animation>().enabled = false;
		GetComponent<CharacterMotor>().enabled = false;
		activateRecursively(transform.Find("master"), true);
		setRagdoll (true);
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


}
