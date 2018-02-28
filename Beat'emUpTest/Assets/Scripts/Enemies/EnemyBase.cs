using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int health = 100;
    public int damage = 5;
    public GameObject textFloat;

    Player playerScript;
    LevelManager levelManager;

    //If we get the combat down.
    //public int prodDamage = 25;
    void Start()
    {
        playerScript = GameManager.gm.player.GetComponent<Player>();

        levelManager = GameManager.gm.levelManager.GetComponent<LevelManager>();
        levelManager.EnemiesInGame.Add(this.gameObject);
    }

    void Update()
    {
        if (health <= 0)
        {
            //GameManager.gm.score.score += 100;
            levelManager.enemiesKilledInPhase++;
            Debug.Log(levelManager.enemiesKilledInPhase);
            levelManager.EnemiesInGame.Remove(this.gameObject);
            textFloat.GetComponent<FloatingNumbers>().popUpNumber = "100";
            textFloat.GetComponent<FloatingNumbers>().GetComponent<TextMesh>().color = new Color(1, 0.92f, 0.016f, 1);
            Instantiate(textFloat, transform.position, transform.rotation);
            Destroy(this.gameObject);

        }
    }


}

