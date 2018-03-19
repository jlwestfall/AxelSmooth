using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour {

	PlayerController playerController;
	Player player;

	public SpriteRenderer playerSprite;
	[Space(5)]
	[Header("Holder Positions")]
	
	public Vector3[] swingPosRot;
	
	public Vector3[] walkPosRots;
	
	public Vector3[] idlePosRot;

	public Vector3[] stunPosRot;
	

	public bool idle;
	[HideInInspector]
	public int index;
	[HideInInspector]
	public int spriteIndex;
	[HideInInspector]
	public string stringState;
	[Space(10)]
	[Header("Weapon Positioning Tool")]
	public Vector3[] currentlyEditing;
	public Sprite[] weaponSprites;
	public Sprite[] idleSprites;
	public Sprite[] walkSprites;
	public Sprite[] attackSprites;
	public Sprite[] stunSprites;

	public WeaponAnimation weaponState;


	void Start () {
		playerController = gameObject.transform.root.gameObject.GetComponent<PlayerController>();
		player = gameObject.transform.root.gameObject.GetComponent<Player>();
		
	}
	public enum WeaponAnimation{
		WALK, IDLE, ATTACK,STUN
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
		if(rb.velocity == Vector3.zero && !playerController.isAttacking && playerController.animator.GetBool("Stunned") == false){
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
			print("Attack State");
		}
		if(idle){
			currentTransformChange = idlePosRot[index];
			currentTransformChange.z = idlePosRot[index].z;
			print("Idle State");
		}else if(playerController.animator.GetBool("Walking") == true){
			
			currentTransformChange = walkPosRots[index];
			currentTransformChange.z = walkPosRots[index].z;
			print("Walk State");
		}
		
		if(playerController.animator.GetBool("Stunned") == true){
			currentTransformChange = stunPosRot[0];	
			print("Index: " + index);
			currentTransformChange.z = stunPosRot[0].z;
		}
		transform.localEulerAngles = new Vector3(0,0, currentTransformChange.z);

		transform.localPosition = new Vector3(currentTransformChange.x,currentTransformChange.y, 0);
		
		
	}

}
