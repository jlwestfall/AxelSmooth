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
	public Vector3[] deadPosRot;
	

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
	public Sprite[] deadSprites;
	public Sprite[] attackSprites;
	public Sprite[] stunSprites;

	public WeaponAnimation weaponState;


	void Start () {
		playerController = gameObject.transform.root.gameObject.GetComponent<PlayerController>();
		player = gameObject.transform.root.gameObject.GetComponent<Player>();
		
	}
	public enum WeaponAnimation{
		WALK, IDLE, ATTACK,STUN, DEATH
	}
	// Update is called once per frame
	void Update () {
		Rigidbody rb = gameObject.transform.root.gameObject.GetComponent<Rigidbody>();
		if(player.equiped == Player.Weapons.Weapon){
			gameObject.transform.GetChild(0).gameObject.SetActive(true);
		}else{
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
		

		if(playerController.isAttacking == true && index < swingPosRot.Length && playerController.gameObject.GetComponent<Player>().curHealth >0){
			currentTransformChange = swingPosRot[index];
			currentTransformChange.z = swingPosRot[index].z;
			
		}
		if(idle && index < idlePosRot.Length){
			currentTransformChange = idlePosRot[index];
			currentTransformChange.z = idlePosRot[index].z;
		
		}else if(playerController.animator.GetBool("Walking") == true && index < walkPosRots.Length && playerController.gameObject.GetComponent<Player>().curHealth >0){
			
			currentTransformChange = walkPosRots[index];
			currentTransformChange.z = walkPosRots[index].z;
		
		}
		
		if(playerController.isStunned == true && index < stunPosRot.Length && playerController.gameObject.GetComponent<Player>().curHealth >0){
			currentTransformChange = stunPosRot[index];	
			
			currentTransformChange.z = stunPosRot[index].z;
		}

		if(playerController.gameObject.GetComponent<Player>().curHealth <= 0 && index < stunPosRot.Length){
			currentTransformChange = deadPosRot[index];	
		
			currentTransformChange.z = deadPosRot[index].z;
		}
		transform.localEulerAngles = new Vector3(0,0, currentTransformChange.z);

		transform.localPosition = new Vector3(currentTransformChange.x,currentTransformChange.y, 0);
		
		
	}

}
