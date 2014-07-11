using UnityEngine;
using System.Collections;

public class ProjectileWeapon : Weapon {

	public Transform projectile;

	public override void attack(Transform t) {
		Transform g = (Transform) Instantiate(projectile, t.position + t.forward, t.rotation);
		g.rigidbody.velocity = t.parent.GetComponent<CharacterController>().velocity;
		base.attack(t);
	}
}
