﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour 
{
	public PlayerSlot playerSlot;
	public KeyCode meleeInput;
	public KeyCode shootInput;
	public float walkMovementSpeed;
	public float projSpeed = 10;
	public float xMin, xMax;
	public float zMin, zMax;

	private float movementSpeed;
	public bool facingRight;
	private bool canMove = true;
	private bool isGrounded;
	public bool hitEffectSwitch;
	Vector3 jump;

	public GameObject attackBox;
	public GameObject hitEffect;

	public GameObject projectile;
	public GameObject projSpawner;
	 Rigidbody rigidbody;
	 Animator animator;
	 Player player;
	 EnemyBase enemyBase;
	 LevelManager levelManager;

	 float moveHorizontal;
	float moveVertical;

	public enum PlayerSlot{
		Player1, Player2
	}
	
	// Use this for initialization
	void Start () 
	{
		rigidbody = GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();
		switch(playerSlot){
			case PlayerSlot.Player1: player = GameManager.gm.player.GetComponent<Player>(); break;
			case PlayerSlot.Player2: player = GameManager.gm.player2.GetComponent<Player>(); break;
		}
		player = GetComponent<Player>();
		levelManager = GameManager.gm.levelManager.GetComponent<LevelManager>();
		enemyBase = new EnemyBase();
		movementSpeed = walkMovementSpeed;
		facingRight = true;
		canMove = true;
		isGrounded = true;
		attackBox.SetActive(false);
		jump = new Vector3(0.0f, 3.5f, 0.0f);

		Physics.gravity = new Vector3(0,-50.0f,0);	
	}
	

	void Update()
	{
		Move();

		if(player.curHealth <= 0)
			SceneManager.LoadScene("GameOver");
	}

	void Move()
	{
		{
			
			
			switch(playerSlot){
				case PlayerSlot.Player1: 
					moveHorizontal = Input.GetAxis ("Horizontal");
					moveVertical = Input.GetAxis ("Vertical"); break;
				case PlayerSlot.Player2:
					moveHorizontal = Input.GetAxis ("Horizontal2");
					moveVertical = Input.GetAxis ("Vertical2"); break;
			}

			Vector3 movement = new Vector3 (moveHorizontal, 0f, moveVertical);

				rigidbody.velocity = movement * movementSpeed;
			if(isGrounded == true)
			{
				if(rigidbody.velocity.x != 0 || rigidbody.velocity.z !=0)	
					animator.SetBool("Walking", true);
				else	
					animator.SetBool("Walking", false);
			}
			else
				animator.SetBool("Walking", false);

			rigidbody.position = new Vector3 
									(
										Mathf.Clamp(rigidbody.position.x, xMin, xMax),
										transform.position.y, 
										Mathf.Clamp (rigidbody.position.z, zMin, zMax)
									);

			
		if(moveHorizontal > 0 && !facingRight)		
			Flip();
			else if(moveHorizontal < 0 && facingRight)
				Flip();
			}

		if(!isGrounded)
			movementSpeed *= .6f;
		else
			movementSpeed = walkMovementSpeed;


<<<<<<< HEAD
		if(Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Joystick1Button0))		
=======
		/*if(Input.GetButton("Jump") && isGrounded == true)
		{
			rigidbody.AddForce(jump * jumpPower, ForceMode.Acceleration);
			isGrounded = false;
		}*/

		//animator.SetFloat("Speed", rigidbody.velocity.sqrMagnitude);

		if(Input.GetMouseButtonUp(0) || Input.GetKeyUp(meleeInput))		
>>>>>>> b818124cab4372c652e14c7122c7fb9a6810795f
		{
			animator.SetBool("Attack1", true);
		}
		else
		{
			animator.SetBool("Attack1", false);
		}

		if(Input.GetKeyUp(shootInput) || Input.GetMouseButtonUp(1))
			animator.SetBool("Shoot", true);
		else
			animator.SetBool("Shoot", false);	
		
	}

	void Flip ()
	{
		facingRight = !facingRight;
		Vector3 thisScale = transform.localScale;
		thisScale.x *= -1;
		transform.localScale = thisScale;
	}

	void Projectile(int powerCost)
	{
		if(player.curPower>= 5)
		{
			GameObject fireClone;
			Rigidbody rigidbody;

			fireClone = (Instantiate(projectile, projSpawner.transform.position, projSpawner.transform.rotation)) as GameObject;
			rigidbody = fireClone.GetComponent<Rigidbody>();

			if(facingRight)
				rigidbody.velocity = (fireClone.transform.right * projSpeed);
			else
				{
					Vector3 thisScale = fireClone.transform.localScale;
					thisScale.x *= -1;
					fireClone.transform.localScale = thisScale;
					rigidbody.velocity = (fireClone.transform.right * -projSpeed);
				}
			player.curPower -= powerCost; 
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "PlayerHit")
		{
			player.curHealth -= enemyBase.damage;
		}

	}

	public void AttackBoxOn()
	{
		attackBox.SetActive(true);

		if(hitEffectSwitch)
			hitEffect.SetActive(true);
	}
	
	public void AttackBoxOff()
	{
		attackBox.SetActive(false);
		hitEffect.SetActive(false);
	}

	public void FireGun()
	{
		Projectile(10);
	}
}
