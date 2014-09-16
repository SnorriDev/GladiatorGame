using UnityEngine;
using System.Collections;

public class AnimationManager : MonoBehaviour {

	public AnimationClip walking;
	public AnimationClip running;
	public AnimationClip hurtWalking;
	public AnimationClip idle;

	public AnimationClip meleeAttack;

	public float walkSpeed;
	public float runSpeed;

	private bool isPunching;
	//maybe get rid of running?
	
	private CharacterController characterController;

	void Start () {
		characterController = transform.GetComponent<CharacterController>();
		isPunching = false;
	}

	private IEnumerator endPunch() {
		Debug.Log ("started punch");
		float dur = meleeAttack.length;
		yield return new WaitForSeconds(dur);
		Debug.Log ("ended punch");
		isPunching = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isPunching) {
			animation.CrossFade (meleeAttack.name);
			StartCoroutine (endPunch ());
		} else {
			if (characterController.velocity.magnitude < walkSpeed)
				animation.CrossFade (idle.name);
			else if (characterController.velocity.magnitude < runSpeed)
				animation.CrossFade (walking.name);
			else
				animation.CrossFade (running.name);
		}

	}

	public void punch () {
		isPunching = true;
	}

}
