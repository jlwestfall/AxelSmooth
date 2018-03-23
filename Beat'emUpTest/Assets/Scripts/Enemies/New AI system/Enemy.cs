using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy : MonoBehaviour
{
	public float attackRange = 1f;
	public float closeAttackRange =  2f;
	public float midRangeDistance = 3f;
	public float farRangeDistance = 4f;
	public float walkSpeed = 110f;
	public float sightDistance = 50f;
	public float attackInterval = 2f;
	public bool targetSpotted;
	
}
