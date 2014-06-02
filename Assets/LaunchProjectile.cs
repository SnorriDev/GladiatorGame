using UnityEngine;
using System.Collections;

public class LaunchProjectile : MonoBehaviour {

	public Transform projectile; //bullet
	public Transform box; //temporary box for spawning boxes

	public Texture2D reticle; //reticle
	public Texture2D coolBar; //bar showing how much time you have to wait before you can shoot again
	//public Vector2 centerReticle;

	private float coolBarPosX; //X position of the cool down bar
	private float coolBarPosY; //Y position of the cool down bar
	private float coolBarHeight; //height of the cool down bar
	private float coolBarLength; //length of the cool down bar (proportional to time remaining to shoot

	public int maxAmmo; //maximum ammount of ammo in gun at time
	public int availableAmmo; //remaining bullets
	private int ammo; //bullets in gun

	public float coolTime; //time between each shot
	public float reloadTime; //time to reload (note: total reload time = reloadTime + coolTime to prevent reload cheating
	private float shotDelay; //total time before you can shoot again

	void Start () {
		ammo = maxAmmo;
		shotDelay = 0;
		// = new Vector2 (((Screen.width - 32) / 2), ((Screen.height  - 32) / 2));
	}


	void Update () {
		if (Input.GetButtonDown ("Fire1") && shotDelay <= 0 && ammo > 0) { //shooting mechanism
			Transform g = (Transform) Instantiate(projectile, transform.position + transform.forward, transform.rotation);
			g.rigidbody.velocity = transform.parent.GetComponent<CharacterController>().velocity;
			ammo --;
			shotDelay = coolTime;

			coolBarPosX = 0;
			coolBarPosY = Screen.height - 60;
			coolBarHeight = 40;
			coolBarLength = 0;
		}

		if (Input.GetButtonDown ("Fire2")) { //reload mechanism
			if (availableAmmo >= (maxAmmo - ammo) && availableAmmo > 0) {
				availableAmmo = availableAmmo - maxAmmo + ammo;
				ammo = maxAmmo;
				shotDelay = coolTime + reloadTime;
			}
			if (availableAmmo < (maxAmmo-ammo) && availableAmmo > 0) {
				ammo = ammo + availableAmmo;
				availableAmmo = 0;
				shotDelay = coolTime + reloadTime;
			}
			if (availableAmmo <= 0) {
				ammo = ammo + 0;
			}
		}

		if (shotDelay >= 0) { //cool down mechanism
			shotDelay -= Time.deltaTime;
		}

		if (Input.GetKeyDown(KeyCode.B)) {//dev box placing feature
			Instantiate(box, transform.position + transform.forward * 5 + transform.right, transform.rotation);
		}
		coolBarLength = shotDelay * Screen.width / 2; //length of cool down bar
	}


	void OnGUI () {
		GUI.DrawTexture(new Rect((Screen.width - reticle.width) / 2, (Screen.height - reticle.height) /2, reticle.width, reticle.height),reticle); //draws reticle
		GUI.DrawTexture(new Rect(coolBarPosX, coolBarPosY, coolBarLength, coolBarHeight),coolBar); //display cool down time
	}
}