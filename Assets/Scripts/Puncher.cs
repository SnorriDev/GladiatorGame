using UnityEngine;
using System.Collections;

public class Puncher : MonoBehaviour {
	
	public float punchDelay;
	private float punchTime;

	public GameObject target;
	private Vector3 targetTran;

	public float maxRange;
	public float minRange;

	private bool isPunching;

	// Use this for initialization
	void Start () {
		punchTime = punchDelay;
		target = GameObject.Find ("First Person Controller");
		targetTran = target.transform.position;
		isPunching = false;
	}	
	
	// Update is called once per frame
	void Update () {
		if ((Vector3.Distance(transform.position, target.transform.position) < maxRange) && (Vector3.Distance(transform.position, target.transform.position) > minRange)) {
			transform.LookAt(targetTran);
			transform.Translate(Vector3.forward * Time.deltaTime);
			punch ();
		}

		if (punchTime != punchDelay) {
			punchTime -= Time.deltaTime;
			if (punchTime <= 0) {
				punchTime = punchDelay;
				GetComponent<AnimationManager>().punch();
				isPunching = false;
			}
		}

		if (isPunching)
			Debug.Log ("punch");
	}

	public void punch () {
		punchTime = punchDelay - 0.01f;
		isPunching = true;
	}
}
