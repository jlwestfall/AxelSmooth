using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy : MonoBehaviour
{
	public float attackRange = 1f;
	public float closeAttackRange =  6f;
	public float midRangeDistance = 10f;
	public float farRangeDistance = 15f;
	public float walkSpeed = 200f;
	public float sightDistance = 50f;
	public float attackInterval = 1f;
	public bool targetSpotted;




	// Destroy event

	void Update()
	{
	}


	void Awake()
	{
		
	}
	
}
