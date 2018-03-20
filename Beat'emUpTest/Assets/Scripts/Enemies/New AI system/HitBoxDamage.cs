using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxDamage : MonoBehaviour
{

    Player playerScript;
    PlayerController playerController;
	LevelManager levelManager;
    public float hitCoolDown;
    public float hitTimer;
    public bool isHit = false;


    Enemy enemy;
    EnemyStats enemyStats;
    GameObject attackBox;


    void Start()
    {
        hitTimer = hitCoolDown;
        playerScript = GameManager.gm.player.GetComponent<Player>();
        playerController = GameManager.gm.player.GetComponent<PlayerController>();
        attackBox = this.gameObject.GetComponent<EnemyActions>().currentAttackBox;
		levelManager = GameManager.gm.levelManager.GetComponent<LevelManager>();
        enemyStats = this.gameObject.GetComponent<EnemyStats>();
    }

    void Update()
    {
        if (enemyStats.health <= 0)
        {
			EnemyAI enemyAI;
			enemyAI = this.gameObject.GetComponent<EnemyAI>();
			enemyAI.currentAttackBox = null;

            GameManager.gm.Death(this.gameObject, 3);
            GetComponent<EnemyAI>().enemyTactic = ENEMYTACTIC.STANDSTILL;
            GetComponent<EnemyAI>().target = null;
			levelManager.enemiesKilledInPhase++;
        if(attackBox != null)
            attackBox.SetActive(false);
        }



        if (isHit && hitTimer > 0)
        {
            hitTimer -= 1 * Time.deltaTime;
        }
        else
        {
            hitTimer = hitCoolDown;
            isHit = false;
        }

        if (playerScript.curPower <= 0)
        {
            playerScript.curPower = 0;
            playerScript.equiped = Player.Weapons.Melee;
            playerScript.powerScript.gameObject.SetActive(false);
        }


    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            enemyStats.health -= playerScript.projDamage;
            Destroy(other.gameObject);
        }


    }

    void OnTriggerEnter(Collider other)
    {
        EnemyActions enAction = GetComponent<EnemyActions>();
        if (other.gameObject.tag == "Hit" && /*!enAction.isStunned &&*/ !isHit)
        {
            isHit = true;
            WeaponManage();


        }
    }

    public void WeaponManage()
    {
        if (playerScript.equiped == Player.Weapons.Melee)
        {
            enemyStats.health -= playerScript.meleeDamage;
        }

        if (playerScript.equiped == Player.Weapons.Weapon)
        {

            enemyStats.health -= playerScript.damage;
            if (playerScript.curPower > 0)
            {
                playerScript.curPower -= playerScript.currentDurability;
            }
        }
    }
}
