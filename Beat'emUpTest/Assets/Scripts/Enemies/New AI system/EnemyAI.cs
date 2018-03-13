using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 
public enum ENEMYSTATE
{
    IDLE,
    ATTACK,
    MOVE,
    HIT,
    KNOCKDOWN,
    KNOCKDOWNGROUNDED,
    DEATH
}

public enum ENEMYTACTIC
{
    ENGAGE = 0,
    KEEPSHORTDISTANCE = 1,
    KEEPMEDIUMDISTANCE = 2,
    KEEPFARDISTANCE = 3,
    STANDSTILL = 4,
}

public enum RANGE
{
    ATTACKRANGE,
    CLOSERANGE,
    MIDRANGE,
    FARRANGE,
}

public enum DIRECTION
{
    LEFT, RIGHT,
}
#endregion



public class EnemyAI : EnemyActions
{
    public float XDistance = 0;
    public float YDistance = 0;

    LevelManager levelManager;
    Rigidbody rigidbody;
    Animator animator;

    private List<ENEMYSTATE> ActivateAIStates = new List<ENEMYSTATE> { ENEMYSTATE.IDLE, ENEMYSTATE.MOVE };
    private List<ENEMYSTATE> HitStates = new List<ENEMYSTATE> { ENEMYSTATE.DEATH, ENEMYSTATE.KNOCKDOWN, ENEMYSTATE.KNOCKDOWNGROUNDED };

    void Start()
    {
        enemyAnimator = this.GetComponent<Animator>();
        rigidBody = this.GetComponent<Rigidbody>();
        levelManager = GameManager.gm.levelManager.GetComponent<LevelManager>();
        levelManager.EnemiesInGame.Add(this.gameObject);
        rigidbody = this.GetComponent<Rigidbody>();
        animator = this.GetComponent<Animator>();

        RandomizeValues();
    }

    void OnEnable()
    {
        SetTargetToPlayers();
    }

    void Update()
    {
		AI();
    }

    void AI()
    {
        LookAtTarget();
        range = GetRangeToTarget();

        //attack range
        if (range == RANGE.ATTACKRANGE)
        {
			if(enemyTactic == ENEMYTACTIC.ENGAGE)
				Attack();
			if(enemyTactic == ENEMYTACTIC.KEEPSHORTDISTANCE)
				MoveTo(closeAttackRange, walkSpeed);
			if(enemyTactic == ENEMYTACTIC.KEEPMEDIUMDISTANCE)
				MoveTo(midRangeDistance, walkSpeed);
			if(enemyTactic == ENEMYTACTIC.KEEPFARDISTANCE)
				MoveTo(farRangeDistance, walkSpeed);
            if(enemyTactic == ENEMYTACTIC.STANDSTILL)
                Idle();
        }
        
        // close range
        if(range == RANGE.CLOSERANGE)
        {
            if(enemyTactic == ENEMYTACTIC.ENGAGE) 
                MoveTo(attackRange - 2, walkSpeed);
            if(enemyTactic == ENEMYTACTIC.KEEPSHORTDISTANCE) 
                MoveTo(closeAttackRange, walkSpeed);
            if(enemyTactic == ENEMYTACTIC.KEEPMEDIUMDISTANCE) 
                MoveTo(midRangeDistance, walkSpeed);
            if(enemyTactic == ENEMYTACTIC.KEEPFARDISTANCE) 
                MoveTo(farRangeDistance, walkSpeed);
            if(enemyTactic == ENEMYTACTIC.KEEPSHORTDISTANCE) 
                MoveTo(closeAttackRange, walkSpeed);
            if(enemyTactic == ENEMYTACTIC.STANDSTILL)
                Idle();  
        }

        if(range == RANGE.MIDRANGE)
        {
            if(enemyTactic == ENEMYTACTIC.ENGAGE) 
                MoveTo(attackRange -.5f, walkSpeed);
            if(enemyTactic == ENEMYTACTIC.KEEPSHORTDISTANCE) 
                MoveTo(closeAttackRange, walkSpeed);
            if(enemyTactic == ENEMYTACTIC.KEEPMEDIUMDISTANCE) 
                MoveTo(midRangeDistance, walkSpeed);
            if(enemyTactic == ENEMYTACTIC.KEEPFARDISTANCE) 
                MoveTo(farRangeDistance, walkSpeed);
            if(enemyTactic == ENEMYTACTIC.KEEPSHORTDISTANCE) 
                MoveTo(closeAttackRange, walkSpeed);
            if(enemyTactic == ENEMYTACTIC.STANDSTILL)
                Idle();  
        }

        if(range == RANGE.FARRANGE)
        {
            if(enemyTactic == ENEMYTACTIC.ENGAGE) 
                MoveTo(attackRange -.5f, walkSpeed);
            if(enemyTactic == ENEMYTACTIC.KEEPSHORTDISTANCE) 
                MoveTo(closeAttackRange, walkSpeed);
            if(enemyTactic == ENEMYTACTIC.KEEPMEDIUMDISTANCE) 
                MoveTo(midRangeDistance, walkSpeed);
            if(enemyTactic == ENEMYTACTIC.KEEPFARDISTANCE) 
                MoveTo(farRangeDistance, walkSpeed);
            if(enemyTactic == ENEMYTACTIC.KEEPSHORTDISTANCE) 
                MoveTo(closeAttackRange, walkSpeed);
            if(enemyTactic == ENEMYTACTIC.STANDSTILL)
                Idle();  
        }

    }

    private RANGE GetRangeToTarget()
    {
        XDistance = DistanceToTargetX();
        YDistance = DistanceToTargetZ();

        //Attack range
        if (XDistance <= attackRange && YDistance <= 1f)
            return RANGE.ATTACKRANGE;

        //Close range
        if (XDistance > attackRange && XDistance < midRangeDistance)
            return RANGE.CLOSERANGE;

        //Mid range
        if (XDistance > closeAttackRange && XDistance < farRangeDistance)
            return RANGE.MIDRANGE;

        //Far range
        if (XDistance > farRangeDistance)
            return RANGE.FARRANGE;

        return RANGE.FARRANGE;
    }

    public void SetEnemyTactic(ENEMYTACTIC tactic)
    {
        enemyTactic = tactic;
    }

    void LookForTarget()
    {
        targetSpotted = DistanceToTargetX() < sightDistance;
    }

}
