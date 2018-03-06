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
	public bool enableAI;	
	private List<ENEMYSTATE> ActivateAIStates = new List<ENEMYSTATE> {ENEMYSTATE.IDLE, ENEMYSTATE.MOVE}; 
	private List<ENEMYSTATE> HitStates = new List<ENEMYSTATE> {ENEMYSTATE.DEATH, ENEMYSTATE.KNOCKDOWN, ENEMYSTATE.KNOCKDOWNGROUNDED};

    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {

    }

}
