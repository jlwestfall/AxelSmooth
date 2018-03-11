using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public PlayerChoice currPlayer;
    public KeyCode meleeInput;
    public KeyCode shootInput;
    public KeyCode dodgeInput;
    public bool rolling;
    public bool isAttacking;
    public float rollTimer = 0.8f;
    public float attackTimer = 0.8f;
    public float walkMovementSpeed;
    public float projSpeed = 10;
    public float xMin, xMax;
    public float zMin, zMax;

    private float movementSpeed;
    public bool facingRight;
    private bool canMove = true;
    public bool hitEffectSwitch;
    private bool p1, p2;

    public GameObject attackBox;
    public GameObject hitEffect;

    public GameObject projectile;
    public GameObject projSpawner;
    public GameObject playerObj;
    public GameObject playerColObj;
    public GameObject playerHitBox;
    public GameObject targetedEnem;
    Rigidbody rigidbody;
    Animator animator;
    Player player;
    Enemy enemy;
    LevelManager levelManager;

    float moveHorizontalPlayer1;
    float moveVerticalPlayer1;
    float moveHorizontalPlayer2;
    float moveVerticalPlayer2;

    public enum PlayerChoice
    {
        PlayerOne, PlayerTwo
    }

    void Awake()
    {
        
    }

    void Start()
    {
        
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        levelManager = GameManager.gm.levelManager.GetComponent<LevelManager>();
        enemy = new Enemy();
        movementSpeed = walkMovementSpeed;
        facingRight = true;
        canMove = true;
        attackBox.SetActive(false);

        //Physics.gravity = new Vector3(0, -50.0f, 0);

        //trying to ignore collision on with P1 && P2
        //Physics.IgnoreCollision(playerObj.GetComponent<Collider>(), GetComponent<Collider>());

        if (currPlayer == PlayerChoice.PlayerOne)
        {
            player = GameManager.gm.player.GetComponent<Player>();
            playerObj = GameManager.gm.player;
            p1 = true;
            p2 = false;
            transform.position = new Vector3(xMin - 12,transform.position.y, transform.position.z);
        }

        else if (currPlayer == PlayerChoice.PlayerTwo)
        {
            player = GameManager.gm.player2.GetComponent<Player>();
            playerObj = GameManager.gm.player2;
            p2 = true;
            p1 = false;
        }

        

    }
    void FixedUpdate()
    {
        Move();

        if (player.curHealth <= 0)
        {
            levelManager.PlayersInGame.Remove(this.gameObject);
            this.gameObject.SetActive(false);
        }

        if (levelManager.PlayersInGame.Count == 0)
            SceneManager.LoadScene("GameOver");

    }

    void Move()
    {
        switch (currPlayer)
        {
            case (PlayerChoice.PlayerOne):
                player = GameManager.gm.player.GetComponent<Player>();
                if (animator.GetBool("dodge") == false)
                {
                    moveHorizontalPlayer1 = Input.GetAxis("Horizontal_P1");
                    moveVerticalPlayer1 = Input.GetAxis("Vertical_P1");
                }
                break;

            case (PlayerChoice.PlayerTwo):
                player = GameManager.gm.player2.GetComponent<Player>();
                if (animator.GetBool("dodge") == false)
                {
                    moveHorizontalPlayer2 = Input.GetAxis("Horizontal_P2");
                    moveVerticalPlayer2 = Input.GetAxis("Vertical_P2");
                }
                break;
        }
        PlayerWork();
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 thisScale = transform.localScale;
        thisScale.x *= -1;
        transform.localScale = thisScale;
    }

    void Projectile(int powerCost)
    {
        if (player.curPower >= 5)
        {
            GameObject fireClone;
            Rigidbody rigidbody;

            fireClone = (Instantiate(projectile, projSpawner.transform.position, projSpawner.transform.rotation)) as GameObject;
            rigidbody = fireClone.GetComponent<Rigidbody>();

            if (facingRight)
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

    public void PlayerWork()
    {
        switch (currPlayer)
        {
            case (PlayerChoice.PlayerOne):
                Vector3 movement = new Vector3(moveHorizontalPlayer1, 0f, moveVerticalPlayer1);
                
                    rigidbody.velocity = movement * movementSpeed;
               
                           if (moveHorizontalPlayer1 > 0 && !facingRight)
                    Flip();
                else if (moveHorizontalPlayer1 < 0 && facingRight)
                    Flip();
                

                if (!animator.GetCurrentAnimatorStateInfo(0).IsName("dodge"))
                    rigidbody.velocity = movement * movementSpeed;


                if (!animator.GetCurrentAnimatorStateInfo(0).IsName("dodge"))
                    rigidbody.velocity = movement * movementSpeed;


                if (!animator.GetCurrentAnimatorStateInfo(0).IsName("dodge"))
                {
                    if (moveHorizontalPlayer1 > 0 && !facingRight)
                        Flip();
                    else if (moveHorizontalPlayer1 < 0 && facingRight)
                        Flip();
                }

                break;

            case (PlayerChoice.PlayerTwo):

                Vector3 movement2 = new Vector3(moveHorizontalPlayer2, 0f, moveVerticalPlayer2);

                if(!rolling)
                    rigidbody.velocity = movement2 * movementSpeed;
  
                if(!rolling)
                     if (moveHorizontalPlayer2 > 0 && !facingRight)
                    Flip();
                else if (moveHorizontalPlayer2 < 0 && facingRight)
                    Flip();

                if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Dodge"))
                    rigidbody.velocity = movement2 * movementSpeed;

                if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Dodge"))
                    rigidbody.velocity = movement2 * movementSpeed;


                if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Dodge"))
                {
                    if (moveHorizontalPlayer2 > 0 && !facingRight)
                        Flip();
                    else if (moveHorizontalPlayer2 < 0 && facingRight)
                        Flip();

                }
                break;
                
        }
    
        movementSpeed = walkMovementSpeed;

        if (rigidbody.velocity.x != 0 || rigidbody.velocity.z != 0)
            animator.SetBool("Walking", true);
        else
            animator.SetBool("Walking", false);

        rigidbody.position = new Vector3(Mathf.Clamp(rigidbody.position.x, xMin, xMax), transform.position.y, Mathf.Clamp(rigidbody.position.z, zMin, zMax));

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(dodgeInput))//Dodge stuff
            animator.SetBool("dodge", true);
        else{
            animator.SetBool("dodge", false);
        }

                if (Input.GetKeyUp(KeyCode.Space) && !rolling && !isAttacking ||
                 Input.GetKeyUp(dodgeInput) && !rolling && !isAttacking)//Dodge stuff
                {
                    
                         animator.SetBool("dodge", true);
                         rolling = true;
                }
                else
                    animator.SetBool("dodge", false);
                
                if (Input.GetKeyDown(shootInput) || Input.GetKeyDown(KeyCode.B)){//Shoot
                    animator.SetBool("Shoot", true);
                }
                else{
                    animator.SetBool("Shoot", false);

                }
        
                if (Input.GetKeyUp(KeyCode.N) && !rolling && !isAttacking ||
                 Input.GetKeyUp(meleeInput) && !rolling && !isAttacking)//Keyboard
                {
                    animator.SetTrigger("Attack0");
                    isAttacking = true;
                }
            
                
            if(rolling){

        if (Input.GetKeyUp(shootInput) || Input.GetKeyUp(KeyCode.B))//Shoot
            animator.SetBool("Shoot", true);
        else
            animator.SetBool("Shoot", false);


        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Dodge"))

            playerHitBox.SetActive(false);
        else
            playerHitBox.SetActive(true);

            }

            if(rolling == true){
                if(rollTimer > 0){
                    rollTimer -= 1 * Time.deltaTime;
                }                  
                else
                {
                    rollTimer = 0.5f;
                    rolling = false;
                }             
            }

            if(isAttacking == true){
                if(attackTimer > 0){
                    attackTimer -= 1 * Time.deltaTime;
                }                  
                else
                {
                    attackTimer = 0.5f;
                    isAttacking = false;
                }             
            }
        
        if(rolling)
            playerHitBox.SetActive(false);
        else
            playerHitBox.SetActive(true);
  
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerHit" && !rolling)
            player.curHealth -= enemy.enemyDMG;

        if (other.gameObject.tag == "PlayerHit" && rolling)
            print("Dodged enemy attack!");


    }

    public void AttackBoxOn()
    {
        attackBox.SetActive(true);

        if (hitEffectSwitch)
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
    

