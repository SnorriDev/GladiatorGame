using UnityEngine;
using System.Collections;

public class AnimationManager : MonoBehaviour {

	public AnimationClip walking;
	public AnimationClip running;
	public AnimationClip hurtWalking;
	public AnimationClip idle;

	public float walkSpeed;
	public float runSpeed;

	//maybe get rid of running?
	
	private CharacterController characterController;

	void Start () {
		characterController = transform.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (characterController.velocity.magnitude < walkSpeed)
			animation.CrossFade (idle.name);
		else if (characterController.velocity.magnitude < runSpeed)
			animation.CrossFade (walking.name);
		else
			animation.CrossFade (running.name);

	}
}
