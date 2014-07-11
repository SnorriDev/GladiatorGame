using UnityEngine;
using System.Collections;

public class BulletTrail : MonoBehaviour {

	public float speed;
	public float endThreshold = 0.5F;

	private Vector3 endPosition;

	public void setEnd(Vector3 end) {
		endPosition = end;
	}

	// Update is called once per frame
	void Update () {

		if ((transform.position - endPosition).magnitude < endThreshold)
			Destroy (gameObject);

		transform.position += transform.forward * speed * Time.deltaTime;
	}
}
