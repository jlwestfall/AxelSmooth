using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour 
{
	public enum LevelPhase
	{
		PHASE1,
		PHASE2,
		PHASE3,
		PHASE4,
		PHASE5,
		CONTINUE
	}	

	public LevelPhase levelPhase;

	public List<GameObject> PlayersInGame = new List<GameObject>();
	public List<GameObject> EnemiesInGame = new List<GameObject>();
	//public List<GameObject> SpawnPhases = new List<GameObject>();

	SpawnManager spawnManager;
	

	public int enemiesKilledInPhase;
	private bool cont = false;
	


	void Start()
	{
		levelPhase = LevelPhase.PHASE1;
		//EnemiesInGame.AddRange(GameObject.FindGameObjectsWithTag("Zombie"));
		PlayersInGame.AddRange(GameObject.FindGameObjectsWithTag("Player"));
		spawnManager = GameManager.gm.spawnManager.GetComponent<SpawnManager>();
	}

	void Update() 
	{

		switch(levelPhase)
		{
			case(LevelPhase.PHASE1):

				if(enemiesKilledInPhase >= 20)
				{
					spawnManager.phase1 = false;

					if(EnemiesInGame.Count == 0)
					{
						enemiesKilledInPhase = 0;
						spawnManager.phase2 = true;
						levelPhase = LevelPhase.PHASE2;
						Debug.Log("we should switch phases now");
					}
				}		

				

			break;

			case(LevelPhase.PHASE2):

				if(enemiesKilledInPhase >= 6)
				{
					spawnManager.phase2 = false;

					if(EnemiesInGame.Count == 0)
					{
						enemiesKilledInPhase = 0;
						spawnManager.phase3 = true;
						levelPhase = LevelPhase.PHASE3;	
					}
				}		

				
			break;

			case(LevelPhase.CONTINUE):

			break;

			/*case(LevelPhase.PHASE3):

				if(enemiesKilledInPhase >= 6)
				{
					spawnManager.phase3= false;
				}		

				if(EnemiesInGame.Count == 0)
				{
					enemiesKilledInPhase = 0;
					levelPhase = LevelPhase.PHASE4;
					spawnManager.phase4 = true;
				}

			break;

			case(LevelPhase.PHASE4):
			break;

			case(LevelPhase.PHASE5):
			break;

			case(LevelPhase.CONTINUE):
			break;
		}*/
		
	}
}
}
