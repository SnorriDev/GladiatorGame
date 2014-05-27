using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour {

	public float maxHealth;
	private float health;

	void Start () {
		health = maxHealth;
	}

	public void damage(float amount) {
		health -= amount;
	}
	
	void Update () {
	
	}
}
