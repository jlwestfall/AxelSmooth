using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour 
{
	Player player;

	public int healthMod = 200;

	void Start()
	{
		player = GameManager.gm.player.GetComponent<Player>();
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Pizza" && player.curHealth < player.maxHealth)
		{
			player.curHealth += healthMod;

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
