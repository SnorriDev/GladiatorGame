using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour {

	//TODO: add damage broadcast system?
	//TODO: make a damage class

	public enum DamageType {PIERCE, CRUSH};

	private KillRagdoll killRagdoll;

	public float maxHealth;
	public float health;
	public float armor;

	void Start () {
		health = maxHealth;
		killRagdoll = GetComponent<KillRagdoll>();
	}

	//TODO: change the type of damage from explosions
	public void damage(float amount) {
		damage (amount, DamageType.PIERCE);
	}

	public void damage(float amount, DamageType type) {
		if (type == DamageType.PIERCE)
			health -= (1 - armor) * amount;
		else
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
