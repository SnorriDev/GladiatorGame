using UnityEngine;
using System.Collections;
using Pathfinding;

public class EnemyAI : MonoBehaviour {

	private CharacterMotor motor;
	private Seeker seeker;
	private Path path;
	private Transform compass;

	private float timeUpdate = .25f;
	private float distUpdate = 1f;

	private int currentWaypoint = 0;

	public float nextWaypointDistance = 0.5f;
	public float turnMargin = 10f;
	public float turnRate = 10f;

	public bool shouldMove = true;

	private Transform target;

	private Vector3 oldPos;
	private float timeFrom;

	// Use this for initialization
	void Start () {
		target = GameObject.Find ("First Person Controller").transform;
		seeker = transform.GetComponent<Seeker>();
		motor = transform.GetComponent<CharacterMotor>();
		compass = transform.Find ("Compass");
		startNewPath ();
	}

	void startNewPath() {
		oldPos = target.position;
		timeFrom = 0;
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

	private void updatePath() {
		timeFrom += Time.deltaTime;
		if (Vector3.Distance (oldPos, target.position) > distUpdate && timeFrom > timeUpdate)
			startNewPath ();
	}

	void FixedUpdate() {

		if (! shouldMove) {
			motor.inputMoveDirection = Vector3.zero;
			return;
		}

		updatePath();

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
		compass.rotation.Set (compass.rotation.x, compass.rotation.y, 0, compass.rotation.w);
		transform.rotation = Quaternion.Lerp (transform.rotation, compass.rotation, Time.deltaTime * turnRate);
		motor.inputMoveDirection = direction;

		if (Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]) < nextWaypointDistance)
			currentWaypoint++;

	}

}
