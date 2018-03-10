using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    LevelManager levelManager;

    void Start()
    {
        levelManager = GameManager.gm.levelManager.GetComponent<LevelManager>();
    }

    void LateUpdate()
    {
		SetEnemyTactics();
    }

    public void SetEnemyTactics()
    {
        if (levelManager.EnemiesInGame.Count > 0)
        {
            for (int i = 0; i < levelManager.EnemiesInGame.Count; i++)
            {
                if (i < 5)
                    levelManager.EnemiesInGame[i].GetComponent<EnemyAI>().SetEnemyTactic(ENEMYTACTIC.ENGAGE);
                else
                    levelManager.EnemiesInGame[i].GetComponent<EnemyAI>().SetEnemyTactic(ENEMYTACTIC.KEEPMEDIUMDISTANCE);
            }
        }
    }
}
