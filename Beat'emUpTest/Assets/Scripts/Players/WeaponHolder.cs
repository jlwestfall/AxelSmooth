using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour {

	PlayerController playerController;
	Player player;

	
	[HideInInspector]
	public Vector3[] swingPosRot;
	[HideInInspector]
	public Vector3[] walkPosRots;
	[HideInInspector]
	public Vector3[] idlePosRot;
	[HideInInspector]
	public bool idle;
	[HideInInspector]
	public int index;
	[HideInInspector]
	public int spriteIndex;
	[HideInInspector]
	public string stringState;
	
	public Vector3[] currentlyEditing;
	public Sprite[] weaponSprites;

	public WeaponAnimation weaponState;


	void Start () {
		playerController = gameObject.transform.root.gameObject.GetComponent<PlayerController>();
		player = gameObject.transform.root.gameObject.GetComponent<Player>();
		
	}
	public enum WeaponAnimation{
		WALK, IDLE, ATTACK
	}
	// Update is called once per frame
	void Update () {
		Rigidbody rb = gameObject.transform.root.gameObject.GetComponent<Rigidbody>();
		if(player.equiped == Player.Weapons.Weapon){
			gameObject.transform.GetChild(0).gameObject.SetActive(true);
		}else{
			print("Should be false");
			gameObject.transform.GetChild(0).gameObject.SetActive(false);
		}
		if(rb.velocity == Vector3.zero && !playerController.isAttacking){
			idle = true;
		}else{
			idle = false;
			
		}
	}

	public void TransformSwitch(int index){
	

	
		Vector3 currentTransformChange = Vector3.zero;
		

		if(playerController.animator.GetBool("Attack") == true){
			currentTransformChange = swingPosRot[index];
			currentTransformChange.z = swingPosRot[index].z;
			print(currentTransformChange);
		}		
		if(playerController.animator.GetBool("Walking") == true){
			print("Walking");
			currentTransformChange = walkPosRots[index];
			currentTransformChange.z = walkPosRots[index].z;
		}
		if(idle){
			currentTransformChange = idlePosRot[index];
			currentTransformChange.z = idlePosRot[index].z;
		}
		transform.localEulerAngles = new Vector3(0,0, currentTransformChange.z);

		transform.localPosition = new Vector3(currentTransformChange.x,currentTransformChange.y, 0);
		
		
	}

}
