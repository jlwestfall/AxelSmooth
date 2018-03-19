using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour 
{
	Player player;
	AudioController audioController;

	public GameObject textFloat;
	public SpriteRenderer myWeapon;
	

	void Start()
	{
		if(this.gameObject.name == "Player")
			player = GameManager.gm.player.GetComponent<Player>();
		if(this.gameObject.name == "Player2")
			player = GameManager.gm.player2.GetComponent<Player>();

		audioController = GameManager.gm.audioController.GetComponent<AudioController>();

	}
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Pizza" && player.curHealth < player.maxHealth)
		{
			audioController.audioSource.PlayOneShot(audioController.pickUp, .5f);
			player.curHealth += 200;

			textFloat.GetComponent<FloatingNumber>().popUpNum = "HP+200";

			if(player.curHealth > player.maxHealth)
				player.curHealth = player.maxHealth;
			Destroy(other.gameObject);
		}

		if(other.gameObject.tag == "Beer" && this.gameObject.name == "Player")
		{
			audioController.audioSource.PlayOneShot(audioController.pickUp, .5f);
			GameManager.gm.score.scoreP1 += 200;

			textFloat.GetComponent<FloatingNumber>().popUpNum = "+200";
			Instantiate(textFloat, other.transform.position, other.transform.rotation);

			Destroy(other.gameObject);
		}

		if(other.gameObject.tag == "Beer" && this.gameObject.name == "Player2")
		{
			GameManager.gm.score.scoreP2 += 200;

			Destroy(other.gameObject);
		}

		if(other.gameObject.tag == "AmmoBox")
		{
			player.curPower += 100;

			if(player.curPower > player.maxPower)
				player.curPower = player.maxPower;
			Destroy(other.gameObject);
		}

		if(other.gameObject.tag == "Weapon")
		{
			WeaponStats stats = other.GetComponent<WeaponStats>();

			textFloat.GetComponent<FloatingNumber>().popUpNum = "" + stats.damage + " Dmg";
			Instantiate(textFloat, other.transform.position, other.transform.rotation);
			player.damage = stats.damage;
			player.currentDurability = stats.durability;
			player.equiped = Player.Weapons.Weapon;
			player.curPower = 100;
			player.powerScript.gameObject.SetActive(true);
			myWeapon.sprite = other.GetComponent<SpriteRenderer>().sprite;
			Destroy(other.gameObject);
		}
	}
}
