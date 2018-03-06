using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy : MonoBehaviour
{
	public float attackRange = 1.5f;
	public float closeAttackRange = 2.5f;
	public float midRangeDistane = 3f;
	public float farRangeDistance = 4.5f;
	public float walkSpeed = 2.5f;
	public string enemyName = "";
	public float sightDistance = 50f;
	public int attackDamage = 2;
	public float attackInterval = 1f;
	public bool targetSpotted;

	// global event handler for enemies.
	public delegate void UnitEventHandler(GameObject Unit);
	public static event UnitEventHandler OnUnitSpawn;

	// global event handler for destroying enemies
	public static event UnitEventHandler OnUnitDestroy;

	// Destroy event
	public void DestroyUnit()
	{
		if(OnUnitDestroy != null) OnUnitDestroy (gameObject);
			Destroy(gameObject);
	}

	public void CreateUnit(GameObject g)
	{
		OnUnitSpawn(g);
	}

	void Awake()
	{
		
	}
}
