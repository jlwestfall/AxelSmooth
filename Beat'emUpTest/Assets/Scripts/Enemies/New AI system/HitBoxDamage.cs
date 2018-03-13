using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxDamage : MonoBehaviour 
{

		Player playerScript;
		PlayerController playerController;
		public GameObject enemyOBJ;
		public float hitCoolDown;
		public float hitTimer;
		public bool isHit = false;
		

		Enemy enemy;


	void Start()
	{
		hitTimer = hitCoolDown;
		playerScript = GameManager.gm.player.GetComponent<Player>();
		playerController = GameManager.gm.player.GetComponent<PlayerController>();
		enemy = enemyOBJ.GetComponent<Enemy>();
	}
	
	void Update()
	{
		if(enemy.enemyHealth <= 0)
		{
			GameManager.gm.Death(this.gameObject.transform.parent.gameObject, 3);
			enemyOBJ.GetComponent<EnemyAI>().enemyTactic = ENEMYTACTIC.STANDSTILL;
		}
			
				

		if(isHit && hitTimer > 0){
			hitTimer -= 1 * Time.deltaTime;
		}else{
			hitTimer = hitCoolDown;
			isHit = false;
		}

		if(playerScript.curPower <= 0){
				playerScript.curPower = 0;
				playerScript.equiped = Player.Weapons.Melee;
				playerScript.powerScript.gameObject.SetActive(false);
		}
	}

	void OnTriggerExit(Collider other)				
	{		
		if(other.gameObject.tag == "Bullet")
		{
			enemy.enemyHealth -= playerScript.projDamage;
			Destroy(other.gameObject);
		}

		if(other.gameObject.tag == "Hit")
		{
			
			playerController.hitEffectSwitch = false;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		EnemyActions enAction = gameObject.transform.root.gameObject.GetComponent<EnemyActions>();
		if(other.gameObject.tag == "Hit" && !enAction.isStunned && !isHit)
		{
			isHit = true;
			playerController.hitEffectSwitch = true;
			WeaponManage();

			
		}
	}

	public void WeaponManage(){
		if(playerScript.equiped == Player.Weapons.Melee){
			enemy.enemyHealth -= playerScript.meleeDamage;
		}

		if(playerScript.equiped == Player.Weapons.Weapon){
		
			enemy.enemyHealth -= playerScript.damage;
			if(playerScript.curPower > 0){
				playerScript.curPower -= playerScript.currentDurability;
			}
		}
	}	
}
