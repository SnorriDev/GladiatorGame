using UnityEngine;
using System.Collections.Generic;

public class LaunchProjectile : MonoBehaviour {

	//TODO: better integrate recoil
	//TODO: pull recoil vector from weapon?
	//TODO: have return statement from attack()
	//TODO: fix up the recoil parameters

	//add the Damage message on the health manager instead of a .damage() method

	public Texture reticle;

	private List<Weapon> weapons;
	private int weaponIndex;

	private Recoil recoiler;
	
	void Start () {

		recoiler = transform.root.Find ("Recoiler").GetComponent<Recoil>();

		weapons = new List<Weapon>();
		Transform weaponFolder = transform.root.Find("Weapons");

		if (weaponFolder != null) {
			foreach (Transform w in weaponFolder) {
				Weapon weapon = w.GetComponent<Weapon> ();
				if (weapon != null)
					weapons.Add (weapon);
			}
		}

		weaponIndex = 0;

	}


	void Update () {
		if (Input.GetButtonDown ("Fire1") && weapons[weaponIndex].canShoot()) { //shooting mechanism
			weapons[weaponIndex].attack(transform);
			recoiler.StartRecoil(.2f, 10f, 10f);
		}

		if (Input.GetButtonDown ("Fire2")) { //reload mechanism
			weapons[weaponIndex].reload();
		}

	}


	void OnGUI () {
		GUI.DrawTexture(new Rect((Screen.width - reticle.width) / 2, (Screen.height - reticle.height) /2, reticle.width, reticle.height),reticle); //draws reticle
		//GUI.DrawTexture(new Rect(coolBarPosX, coolBarPosY, coolBarLength, coolBarHeight),coolBar); //display cool down time
	}
}