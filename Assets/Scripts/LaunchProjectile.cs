using UnityEngine;
using System.Collections.Generic;

public class LaunchProjectile : MonoBehaviour {

	//TODO: basically make these stats be pulled from the weapon
	//TODO: add a script on the weapon with a shoot() method
	//have a weapon transform with attached weapon

	//add the Damage message on the health manager instead of a .damage() method

	public Texture reticle;

	private List<Weapon> weapons;
	private int weaponIndex;
	
	void Start () {

		weapons = new List<Weapon>();
		Transform weaponFolder = transform.parent.Find("Weapons");

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