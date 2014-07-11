using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour {

	//move all the stuff about reloading, etc. into here
	
	public int clipSize; //maximum ammount of ammo in gun at time
	public int availableAmmo; //remaining bullets
	private int ammo; //bullets in gun
	
	public float coolTime; //time between each shot
	public float reloadTime; //time to reload (note: total reload time = reloadTime + coolTime to prevent reload cheating
	private float shotDelay; //total time before you can shoot again

	public AudioClip shootSound;

	public bool canShoot() {
		return shotDelay <= 0 && ammo > 0;
	}

	public void reload() {
		if (availableAmmo >= (clipSize - ammo) && availableAmmo > 0) {
			availableAmmo = availableAmmo - clipSize + ammo;
			ammo = clipSize;
			shotDelay = coolTime + reloadTime;
		}
		if (availableAmmo < (clipSize - ammo) && availableAmmo > 0) {
			ammo = ammo + availableAmmo;
			availableAmmo = 0;
			shotDelay = coolTime + reloadTime;
		}
	}

	//possibly make this not abstract
	public virtual void attack(Transform t) {
		ammo --;
		shotDelay = coolTime;
		Debug.Log (audio);
		if (audio != null)
			audio.Play ();
		//Debug.Log (ammo);
	}

	void Start() {
		ammo = clipSize;
		shotDelay = 0;
		if (audio != null)
			audio.clip = shootSound;
	}

	void Update() {
		if (shotDelay > 0)
			shotDelay -= Time.deltaTime;
	}

}
