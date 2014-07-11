using UnityEngine;
using System.Collections;

public class Damager : MonoBehaviour {

	public float damage;
	public float despawnTime;

	private bool count;

	public void OnCollisionEnter(Collision col) {

		if (col.collider.tag == "Health")
			col.collider.GetComponent<HealthManager> ().damage (damage);
		count = true;
	}

	void Start() {
		count = false;
	}

	void Update() {
		if (count) {
			despawnTime -= Time.deltaTime;
			if (despawnTime <= 0)
				Destroy (gameObject);
		}

	}
}
