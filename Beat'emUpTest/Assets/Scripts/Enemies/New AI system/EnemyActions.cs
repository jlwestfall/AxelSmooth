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
    public Animator enemyAnimator;
    public GameObject target;
    public Rigidbody rigidBody;
    public GameObject attackBoxLeft;
    public GameObject attackBoxRight;

    GameObject currentAttackBox;

    public bool isDead;
    public float zHitDistance = .4f;
    float moveThreshold = 1f;
    public float lastAttackTime;
    private bool attackWhilePlayerIsRolling; // If the enemy will try and attack the player while rolling.

    public bool isStunned;
    public float stunTime;
    public float stunTimer;

    void Start()
    {
        rigidBody = this.gameObject.GetComponent<Rigidbody>();
        enemyAnimator = this.GetComponent<Animator>();
    }

    void Update()
    {
        StunCoolDown();
    }


    public void Attack()
    {
        if (target == null)
            SetTargetToPlayers();

        if (Time.time - lastAttackTime > attackInterval)
        {
            enemyState = ENEMYSTATE.ATTACK;
            Move(Vector3.zero, 0);
            LookAtTarget();
            enemyAnimator.SetTrigger("Punch");
            lastAttackTime = Time.time;
        }

    }

    public void MoveTo(float distance, float speed)
    {
        LookAtTarget();

        // horizontal movement
        if (Mathf.Abs(DistanceToTargetX() - distance) > moveThreshold && !isStunned)
        {
            // move closer on horizontal
            Move(Vector3.right * (int)DirToDistPoint(distance), speed);
            
        }
        else if (Mathf.Abs(DistanceToTargetX() - distance) > moveThreshold && !isStunned)
        {
            // move closer on horizontal
            Move(Vector3.right * (int)DirToDistPoint(distance) * -1, speed);
            
        }
        else if (Mathf.Abs(DistanceToTargetZ() - distance) > moveThreshold && !isStunned)
        {
            // move closer on vert
            Move(Vector3.forward * DirToVertLine(), speed);
            
        }

    }

    float DirToDistPoint(float distance)
    {
        float distancePointX;

        if (target == null)
            SetTargetToPlayers();


        if (transform.position.x < target.transform.position.x)
        {
            distancePointX = target.transform.position.x - distance;

            if (this.transform.position.x < distancePointX)
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
            distancePointX = target.transform.position.x + distance;

            if (this.transform.position.x > distancePointX)
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
        if (target != null)
        {
            if (transform.position.x >= target.transform.position.x)
            {
                this.GetComponent<SpriteRenderer>().flipX = false;
                currentAttackBox = attackBoxLeft;
            }         
            else
            {
                this.GetComponent<SpriteRenderer>().flipX = true;
                currentAttackBox = attackBoxRight;
            }
                
        }
    }

    // return current direction
    public DIRECTION GetCurDirection()
    {
        if (!this.GetComponent<SpriteRenderer>().flipX)
            return DIRECTION.RIGHT;
        else
            return DIRECTION.LEFT;

    }

    // sets direction to wanted position X
    public DIRECTION DirectionToPos(float xPos)
    {
        if (this.transform.position.x >= xPos)
            return DIRECTION.RIGHT;
        else
            return DIRECTION.LEFT;
    }

    // sets direction to wanted positon Z
    int DirToVertLine()
    {
        if (this.transform.position.z > target.transform.position.z)
            return -1;
        else
            return 1;
    }

    public void Idle()
    {
        Move(Vector3.zero, 0);
        enemyState = ENEMYSTATE.IDLE;
        enemyAnimator.SetBool("Walk", false);
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
        if (target != null)
            return Mathf.Abs(this.transform.position.x - target.transform.position.x);
        else
            return -1;
    }

    public float DistanceToTargetZ()
    {
        if (target != null)
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

    public void StunCoolDown()
    {
        if (isStunned && stunTimer < stunTime && !enemyAnimator.GetBool("StunnedStrong"))
        {
            stunTimer += 1 * Time.deltaTime;
        }
        if (isStunned && stunTimer < stunTime && enemyAnimator.GetBool("StunnedStrong"))
        {
            stunTimer += 0.3f * Time.deltaTime;
        }
        if (isStunned && stunTimer >= stunTime)
        {
            isStunned = false;
            stunTimer = 0;
            enemyAnimator.SetBool("Stunned", false);
            enemyAnimator.SetBool("StunnedStrong", false);
        }
    }

    public void IdleOn()
    {
        enemyTactic = ENEMYTACTIC.STANDSTILL;
        target = null;
    }

    public void IdleOff()
    {
        SetTargetToPlayers();
        enemyTactic = ENEMYTACTIC.ENGAGE;
    }

    public void AttackBoxOn()
    {
        currentAttackBox.SetActive(true);
    }

    public void AttackBoxOff()
    {
        currentAttackBox.SetActive(false);
    }



}
