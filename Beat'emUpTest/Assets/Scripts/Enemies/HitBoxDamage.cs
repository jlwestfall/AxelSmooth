using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxDamage : MonoBehaviour 
{

		Player playerScript;
		PlayerController playerController;
		public GameObject enemyOBJ;

		Enemy enemy;


	void Start()
	{
		playerScript = GameManager.gm.player.GetComponent<Player>();
		playerController = GameManager.gm.player.GetComponent<PlayerController>();
		enemy = enemyOBJ.GetComponent<Enemy>();
	}

	void Update()
	{
		if(enemy.enemyHealth <= 0)
			Destroy(enemy.gameObject);	
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
		if(other.gameObject.tag == "Hit")
		{
			playerController.hitEffectSwitch = true;
			enemy.enemyHealth -= playerScript.damage;

			
		}
	}	
}
