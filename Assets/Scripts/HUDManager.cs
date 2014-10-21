using UnityEngine;
using System.Collections;

public class HUDManager : MonoBehaviour {

	private HealthManager hm; // health ratio
	private Weapon weapon;
	private Levels l;


	public Texture2D barTexture;
	public float healthPercent;
	public Rect healthTextField;

	public Texture ammoAvailable;
	public int ammoAvailableText;
	private Rect ammoAvailableField;

	public Texture ammoBackup;
	public int ammoBackupText;
	private Rect ammoBackupTextField;

	private Rect gameOverBox;
	public string gameOver;



	void Start () {
		hm = transform.GetComponent<HealthManager> ();
		weapon = GetComponentInChildren<Weapon> ();
		l = GameObject.Find("Center").GetComponent<Levels> ();

		healthTextField = new Rect (0, Screen.height / 64, 32, Screen.height/24);
		ammoAvailableField = new Rect (0, Screen.height / 64 + 2 * Screen.height / 24, 32, Screen.height/24);
		ammoBackupTextField = new Rect (0, Screen.height / 64 + 3.5F * Screen.height / 24, 32, Screen.height/24);
		gameOverBox = new Rect (Screen.width / 2 - 240, Screen.height / 2 - 120, 480, 240);
	}
	
	// Update is called once per frame
	void OnGUI () {
		healthPercent = hm.health / hm.maxHealth * 100;
		ammoAvailableText = weapon.ammo;
		ammoBackupText = weapon.availableAmmo;

		GUI.Box(new Rect(32, Screen.height/64, Screen.width/8 * hm.getHealthRatio (), Screen.height/24), barTexture);
		GUI.Box(new Rect(32, Screen.height/64 + 2*Screen.height/24, Screen.width/8 * weapon.ammo/weapon.clipSize, Screen.height/24), ammoAvailable);
		GUI.Box(new Rect(32, Screen.height/64 + 3.5F*Screen.height/24, Screen.width/64 * weapon.availableAmmo / weapon.clipSize, Screen.height/24), ammoBackup);

		GUI.TextField (healthTextField, "" + healthPercent);
		GUI.TextField (ammoAvailableField, "" + ammoAvailableText);
		GUI.TextField (ammoBackupTextField, "" + ammoBackupText);

		if (l.gameOver) {
			GUI.TextField (gameOverBox, gameOver);
		}
	}
}
