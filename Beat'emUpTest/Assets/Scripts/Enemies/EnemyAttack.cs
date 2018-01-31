using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour 
{
	private int aIndex;

	private float time;
	EnemyBase enemyBase;

	private Player playerScript;
	private CollidingSwitch collidingSwitch;

	public GameObject attackBox;
	public GameObject rangeBox;
	Animator animator;

	void Start()
	{
		playerScript = GameManager.gm.player.GetComponent<Player>();
		enemyBase = GetComponent<EnemyBase>();
		animator = GetComponent<Animator>();
		collidingSwitch = rangeBox.GetComponent<CollidingSwitch>();
		attackBox.SetActive(false);
	}

	void Update()
	{
		if(collidingSwitch.inRange)
			animator.SetBool("Attack", true);
		else
			animator.SetBool("Attack", false);
	}

	public void AttackBoxOn()
	{
		attackBox.SetActive(true);
	}

	public void AttackBoxOff()
	{
		attackBox.SetActive(false);
	}
	
	
}
