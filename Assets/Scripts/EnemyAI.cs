using UnityEngine;
using System.Collections;
using Pathfinding;

public class EnemyAI : MonoBehaviour {

	private CharacterMotor motor;
	private Seeker seeker;
	private Path path;
	private Transform compass;
	private Transform model;

	private int currentWaypoint = 0;

	public float nextWaypointDistance = 0.5f;
	public float turnMargin = 10f;
	public float turnRate = 10f;
	private Transform target;

	// Use this for initialization
	void Start () {
		target = GameObject.Find ("First Person Controller").transform;
		seeker = transform.GetComponent<Seeker>();
		motor = transform.GetComponent<CharacterMotor>();
		compass = transform.Find ("Compass");
		model = transform.Find ("master");
		startNewPath ();
	}

	void startNewPath() {
		seeker.StartPath (transform.position, target.position, onPathComplete);
	}

	public void onPathComplete(Path newPath) {
		if (! newPath.error) {
			path = newPath;
			currentWaypoint = 0;
		}
	}

	private bool areClose(Vector3 v1, Vector3 v2) {
		return Vector3.Angle (v1, v2) < turnMargin;
	}

	//test if closer to rotated angle on one side
	private void turnTo(Vector3 from, Vector3 to) {
		float weirdDot = from.x * -to.z + from.z * to.x; 

		Vector3 rightNormal = new Vector3(from.z, -from.x);
		Vector3 leftNormal = new Vector3(-from.z, from.x);

		Debug.Log (new Vector3 (from.z, -from.x));

		if (Vector3.Angle(to, rightNormal) < Vector3.Angle (to, leftNormal))
			transform.Rotate (Vector3.up * Time.deltaTime * turnRate);
		else
			transform.Rotate (Vector3.down * Time.deltaTime * turnRate);

	}

	void FixedUpdate() {
		if (path == null || currentWaypoint >= path.vectorPath.Count) {
			motor.inputMoveDirection = Vector3.zero;
			return;
		}
		Vector3 direction = (path.vectorPath[currentWaypoint] - transform.position).normalized;
		
		/*if (areClose(direction, transform.forward))
			motor.inputMoveDirection = direction;
		else
			turnTo(transform.forward, direction);*/
		
		compass.LookAt (path.vectorPath[currentWaypoint]);
		model.rotation = Quaternion.Lerp (model.rotation, compass.rotation, Time.deltaTime * turnRate);
		motor.inputMoveDirection = direction;

		if (Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]) < nextWaypointDistance)
			currentWaypoint++;

	}

}
