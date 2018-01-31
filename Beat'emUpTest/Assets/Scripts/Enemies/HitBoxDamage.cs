using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxDamage : MonoBehaviour 
{

		Player playerScript;
		PlayerController playerController;
		public GameObject enemy;

		EnemyBase enemyBase;

	void Start()
	{
		playerScript = GameManager.gm.player.GetComponent<Player>();
		playerController = GameManager.gm.player.GetComponent<PlayerController>();
		enemyBase = enemy.GetComponent<EnemyBase>();
	}

	void Update()
	{
		if(enemyBase.health <= 0)
			Destroy(enemy.gameObject);	
	}

	void OnTriggerExit(Collider other)				
	{		
		if(other.gameObject.tag == "Bullet")
		{
			enemyBase.health -= playerScript.projDamage;
			Destroy(other.gameObject);
		}

		if(other.gameObject.tag == "Hit")
		{
			playerController.hitEffectSwitch = false;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Hit")
		{
			Debug.Log("something?");
			playerController.hitEffectSwitch = true;
			enemyBase.health -= playerScript.damage;
		}
	}	
}
