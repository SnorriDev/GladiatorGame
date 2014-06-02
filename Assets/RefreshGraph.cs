using UnityEngine;
using System.Collections;

public class RefreshGraph : MonoBehaviour {

	private Vector3 initialPos;

	// Use this for initialization
	void Start () {
		initialPos = transform.position;
	}

	// Update is called once per frame
	void Update () {
		//transform.Translate (Vector3.forward * Time.deltaTime);
		if (Vector3.Distance (initialPos, transform.position) > 1) {
			AstarPath.active.UpdateGraphs(collider.bounds);
			initialPos = transform.position;
		}
	}
}
