using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
	public static GameManager gm;
	[Header("Player Object")]
	public GameObject player;
	public float playerSpeed;
	public GameObject player2;
	public Score score;
	[Header("Level Manager")]
	public GameObject levelManager;
	[Header("Spawn Manager")]
	public GameObject spawnManager;
	public GameObject uiManager;
	public GameObject audioController;

	public List<GameObject> enemiesEngaged = new List<GameObject>();
	
	void Awake()
	{
		if(!gm)
			gm = this;
		else
			Destroy(this.gameObject);
	}

	public void Death(GameObject deadCharacter, float deathWaitTime)
    {
        Animator animator;
        SpriteRenderer spriteRenderer;

        spriteRenderer = deadCharacter.GetComponent<SpriteRenderer>();
        animator = deadCharacter.GetComponent<Animator>();
        animator.SetTrigger("Dead");

        StartCoroutine(DeathWait(deadCharacter, deathWaitTime));
        

    }

    IEnumerator DeathWait(GameObject dC, float timeWait)
    {
        yield return new WaitForSeconds(timeWait);
	if(dC != null){
		 if(dC.tag == "Enemy")
            Destroy(dC.gameObject);
        else
            dC.gameObject.SetActive(false);
	}
       
    }
}
