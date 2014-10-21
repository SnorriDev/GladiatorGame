using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour {

	//TODO: add damage broadcast system?

	private KillRagdoll killRagdoll;

	public float maxHealth;
	public float health;

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

	public float getHealthRatio () {
		return health / maxHealth;
	}

	void Update () {
		if (isDead () && killRagdoll != null) {
			killRagdoll.kill();
		}

		if (Input.GetKeyDown (KeyCode.Z))
			damage (100);

	}

}
