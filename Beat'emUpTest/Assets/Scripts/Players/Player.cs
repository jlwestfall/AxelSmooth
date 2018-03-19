using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
	public int maxHealth = 100;
	public int curHealth;
	public int maxPower = 0;
	public int curPower;
	public int damage = 25;
	public int meleeDamage = 25;
	public int projDamage = 75;
	public int currentDurability = 0;
	public Weapons equiped;
	public HealthPower powerScript;
	public enum Weapons{
		Melee,Weapon
	}

}

