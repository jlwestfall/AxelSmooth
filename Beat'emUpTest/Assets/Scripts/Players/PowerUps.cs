using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour 
{
	Player player;


	void Start()
	{
		player = GameManager.gm.player.GetComponent<Player>();
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Pizza" && player.curHealth < player.maxHealth)
		{
			player.curHealth += 200;

			if(player.curHealth > player.maxHealth)
				player.curHealth = player.maxHealth;
			Destroy(other.gameObject);
		}

		if(other.gameObject.tag == "Beer")
		{
			GameManager.gm.score.score += 200;

			Destroy(other.gameObject);
		}

		if(other.gameObject.tag == "AmmoBox")
		{
			player.curPower += 100;

			if(player.curPower > player.maxPower)
				player.curPower = player.maxPower;
			Destroy(other.gameObject);
		}
	}
}
