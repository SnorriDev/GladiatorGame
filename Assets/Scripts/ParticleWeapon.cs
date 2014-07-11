using UnityEngine;
using System.Collections;

public class ParticleWeapon : Weapon {

	public float damage;
	public float range;
	public Transform lineRenderer;

	public override void attack(Transform t) {

		BulletTrail newLine = ((Transform) Instantiate(lineRenderer, t.position, t.rotation)).GetComponent<BulletTrail> ();

		/*newLine.material = new Material (Shader.Find("Particles/Additive"));
		newLine.SetWidth(0.1F, 0.1F);

		newLine.SetPosition (0, t.position + t.forward);
		*/
		RaycastHit hit;
		if (Physics.Raycast (t.position, t.forward, out hit)) {
			newLine.setEnd (hit.point);
			HealthManager health = hit.transform.GetComponent<HealthManager> ();
			if (health != null)
				health.damage (damage);
		} else
			newLine.setEnd (t.position + t.forward * range);

		base.attack(t);
	}
}
