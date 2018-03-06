using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class EnemyActions : Enemy
{
	// Actions the enemy can take
	public RANGE range;
	public ENEMYTACTIC enemyTactic;
	public ENEMYSTATE enemyState;
	public EnemyAnimations enemyAnimations;
	public GameObject target;
	public Rigidbody rigidBody;

	public bool isDead;
	public float zHitDistance = .4f;
	float moveThreshold = 1f;
	public float lastAttackTime;
	private bool attackWhilePlayerIsRolling; // If the enemy will try and attack the player while rolling.

	void Start()
	{
		rigidBody = this.gameObject.GetComponent<Rigidbody>();
	}

	void Update()
	{
		MoveTo(3f,200f);
	}

	public void MoveTo(float distance, float speed)
	{
		LookAtTarget();


	
		// horizontal movement
		if(Mathf.Abs(DistanceToTargetX() - distance) > moveThreshold )
		{
			// move closer on horizontal
			Move(Vector3.right * (int)DirToDistPoint(distance), speed);
			Debug.Log("happenX");
		}
		else if (Mathf.Abs(DistanceToTargetX() - distance) > moveThreshold )
		{
			// move closer on horizontal
			Move(Vector3.right * (int)DirToDistPoint(distance) * -1, speed);
			Debug.Log("happenX");
		}
		else if (Mathf.Abs(DistanceToTargetZ() - distance) > moveThreshold)
		{	
			// move closer on vert
			Move(Vector3.forward * DirToVertLine(), speed );
			Debug.Log("happenZ");		
		}
				
	}

	float DirToDistPoint(float distance)
	{
		float distancePointX;

		if(target == null) 
			SetTargetToPlayers();

		
		if(transform.position.x < target.transform.position.x)
		{
			distancePointX = target.transform.position.x - distance;

			if(this.transform.position.x < distancePointX)
				{
					return 1;
				}
			else
			{
				return -1;
			}
			
		}
		else
			{	
				Debug.Log("fl;kjdf");
				distancePointX = target.transform.position.x + distance;

				if(this.transform.position.x > distancePointX)
				{
					return -1;
				}
				else
				{
					return 1;
				}

			}
	}

	public void LookAtTarget()
	{
		if(target != null)
		{
			if(transform.position.x >= target.transform.position.x)
				this.GetComponent<SpriteRenderer>().flipX = false;
			else
				this.GetComponent<SpriteRenderer>().flipX = true;
		}		
	}

	// return current direction
	public DIRECTION GetCurDirection()
	{
		if(!this.GetComponent<SpriteRenderer>().flipX)
			return DIRECTION.RIGHT;
		else
			return DIRECTION.LEFT;

	}

	// sets direction to wanted position X
	public DIRECTION DirectionToPos(float xPos)
	{
		if(this.transform.position.x >= xPos)
			return DIRECTION.RIGHT;
		else
			return DIRECTION.LEFT;
	}

	// sets direction to wanted positon Z
	int DirToVertLine()
	{
		if(this.transform.position.z > target.transform.position.z)
			return -1;
		else
			return 1;
	}

	public void Move(Vector3 vector, float speed)
	{
		rigidBody.velocity = vector * speed * Time.deltaTime;
	}

	// wait for x seconds
	public IEnumerator Wait(float delay)
	{
		yield return new WaitForSeconds(delay);
		enemyState = ENEMYSTATE.IDLE;
	}

	public float DistanceToTargetX()
	{
		if(target != null)
			return Mathf.Abs(this.transform.position.x - target.transform.position.x);
		else
			return -1;
	}

	public float DistanceToTargetZ()
	{
		if(target != null)
		{
			return Mathf.Abs(this.transform.position.z - target.transform.position.z);
		}
		else 
			return -1;
	}

	public void SetTargetToPlayers()
	{
		target = GameObject.FindGameObjectWithTag("Player");
	}

	public void RandomizeValues()
	{
		walkSpeed *= Random.Range(.8f, 1.2f);
		attackInterval *= Random.Range(.8f, 1.2f);
	}


	
}
