using UnityEngine;
using System.Collections;

public class BulletTrail : MonoBehaviour {

	public float speed;

	private float distance;
	private float travelled;

	public void setEnd(Vector3 end) {
		distance = Vector3.Distance (transform.position, end);
	}

	void Start() {
		travelled = 0f;
	}

	// Update is called once per frame
	void Update () {

		if (travelled > distance)
			Destroy (gameObject);

		transform.position += transform.forward * speed * Time.deltaTime;
		travelled += (transform.forward * speed * Time.deltaTime).magnitude;
	}
}
