using UnityEngine;
using System.Collections;

public class KillRagdoll : MonoBehaviour {

	// Use this for initialization
	void Start () {
		kill<BoxCollider> ();
	}

	private void kill<E>() where E : Collider {
		foreach (E r in transform.GetComponentsInChildren<E>()) {
			Debug.Log(r);
			((Collider) r).isTrigger = true;
		}

	}

}
