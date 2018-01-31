using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour 
{	

	public float spawnTime = 6f;
	[Header("Spawn Phase 1")]
	public GameObject[] spawnPointsP1;
	[Header("Spawn Phase 2")]
	public GameObject[] spawnPointsP2;
	[Header("Spawn Phase 3")]
	public GameObject[] spawnPointsP3;
	[Header("Spawn Phase 4")]
	public GameObject[] spawnPointsP4;
	[Header("Spawn Phase 5")]
	public GameObject[] spawnPointsP5;

	public GameObject zombie;

	private LevelManager levelManager;

	//Spawn Switches.
	public bool phase1, phase2, phase3, phase4, phase5, cont = false;
	private bool canSpawn;
	

	void Start () 
	{
		levelManager = GameManager.gm.levelManager.GetComponent<LevelManager>();
		phase1 = true;
		StartCoroutine("Phases", spawnTime);
		
	}
	
	void Update()
	{
		
	}

	void Spawn(GameObject[] spawnPhase)
	{
		if(levelManager.EnemiesInGame.Count <= 4)
		{
			int spawnPointIndex = Random.Range(0, spawnPhase.Length);

			Instantiate(zombie, spawnPhase[spawnPointIndex].transform.position, spawnPhase[spawnPointIndex].transform.rotation);
		}
	}

	IEnumerator Phases(float seconds)
	{
		while(phase1)
		{
			Spawn(spawnPointsP1);
			yield return new WaitForSeconds(seconds);			
		}
		while(phase2)
		{
			Spawn(spawnPointsP2);
			yield return new WaitForSeconds(seconds);
		}
		while(phase3)
		{
			Spawn(spawnPointsP3);
			yield return new WaitForSeconds(seconds);
		}
		while(phase4)
		{
			Spawn(spawnPointsP4);
			yield return new WaitForSeconds(seconds);
		}
		while(phase5)
		{
			Spawn(spawnPointsP5);
			yield return new WaitForSeconds(seconds);
		}
	}
}
