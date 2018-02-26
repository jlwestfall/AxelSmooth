using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private int aIndex;

    private float time;
    bool inRange;
    EnemyBase enemyBase;

    private Player playerScript;
    private CollidingSwitch collidingSwitch;

    public GameObject attackBox;
    public GameObject rangeBox;
    Animator animator;

    public int attackI;

    void Start()
    {
        playerScript = GameManager.gm.player.GetComponent<Player>();
        enemyBase = GetComponent<EnemyBase>();
        animator = GetComponent<Animator>();
        collidingSwitch = rangeBox.GetComponent<CollidingSwitch>();
        attackBox.SetActive(false);

		StartCoroutine("AttackRoll", 2);
    }

    void Update()
    {
        if (collidingSwitch.inRange)
            inRange = true;
        else
            inRange = false;
    }

    public void AttackBoxOn()
    {
        attackBox.SetActive(true);
    }

    public void AttackBoxOff()
    {
        attackBox.SetActive(false);
    }

    IEnumerator AttackRoll(float rollTime)
    {
        int attackIndex;
        attackIndex = Random.Range(0, 1);
        attackI = attackIndex;
		yield return new WaitUntil(()=> inRange);
        
        while (inRange)
        {
            
            switch (attackIndex)
            {
                //case (0):
                    //animator.SetTrigger("attack");
                    //break;
                case (0):
					animator.SetTrigger("attack");
                    break;
            }
			yield return new WaitForSeconds(rollTime);

        }

        
    }


}
