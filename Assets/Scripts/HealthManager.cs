using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour {

	//TODO: add damage broadcast system?

	private KillRagdoll killRagdoll;

	public float maxHealth;
	private float health;

	void Start () {
		health = maxHealth;
		killRagdoll = GetComponent<KillRagdoll>();
	}

	public void damage(float amount) {
		health -= amount;
	}

	public bool isDead() {
		return health <= 0;
	}
	
	void Update () {
		if (isDead () && killRagdoll != null) {
			killRagdoll.kill();
		}

		if (Input.GetKeyDown (KeyCode.Z))
			damage (100);

	}

}
