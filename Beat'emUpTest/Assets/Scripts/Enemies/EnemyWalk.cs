using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWalk : MonoBehaviour 
{
	NavMeshAgent navMeshAgent;
	EnemySight enemySight;

	Rigidbody rigidbody;
	Animator animator;

	public float moveSpeed = 2f;
	
	private float targetIndex;
	public bool facingLeft;

	// Use this for initialization
	void Start () 
	{
		navMeshAgent = GetComponent<NavMeshAgent>();
		enemySight = GetComponent<EnemySight>();
		rigidbody = GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();

		navMeshAgent.speed = moveSpeed;

		facingLeft = true;
	}
	
	void Update () 
	{
		GoToPlayer();
		
		if(navMeshAgent.velocity.x != 0 || navMeshAgent.velocity.z != 0)
			animator.SetBool("Walk", true);	
		else
			animator.SetBool("Walk", false);	

	}

	void GoToPlayer()
	{
		navMeshAgent.SetDestination(GameManager.gm.player.transform.position);
		navMeshAgent.updateRotation = false;

		if(navMeshAgent.velocity.x > 0 && facingLeft)
			Flip();
		else if(navMeshAgent.velocity.x < 0 && !facingLeft)
			Flip();
		
	}

	void Flip()
	{
		facingLeft = !facingLeft;
		Vector3 thisScale = transform.localScale;
		thisScale.x *= -1;
		transform.localScale = thisScale;
	}
}
