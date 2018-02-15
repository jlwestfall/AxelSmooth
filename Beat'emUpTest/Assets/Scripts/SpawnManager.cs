using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float spawnTime = 15f;
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
    public bool phase1, phase2, phase3, phase4, phase5 = false;


    void Start()
    {
        levelManager = GameManager.gm.levelManager.GetComponent<LevelManager>();
        phase1 = true;
        StartCoroutine("Phasing", spawnTime);
    }


    void Spawn(GameObject[] spawnPhase)
    {
        if (levelManager.EnemiesInGame.Count <= 4)
        {
            int spawnPointIndex = Random.Range(0, spawnPhase.Length);

            Instantiate(zombie, spawnPhase[spawnPointIndex].transform.position, spawnPhase[spawnPointIndex].transform.rotation);
        }
    }

    IEnumerator Phase1 (float spawnTime)
    {
        yield return new WaitUntil(()=> phase1);

        while(phase1)
        {
            Spawn(spawnPointsP1);
            yield return new WaitForSeconds(spawnTime);
        }
    }

    IEnumerator Phase2 (float spawnTime)
    {
        yield return new WaitUntil(()=> phase2);

        while(phase2)
        {
            Spawn(spawnPointsP2);
            yield return new WaitForSeconds(spawnTime);
        }
    }

    IEnumerator Phase3 (float spawnTime)
    {
        yield return new WaitUntil(()=> phase3);

        while(phase3)
        {
            Spawn(spawnPointsP2);
            yield return new WaitForSeconds(spawnTime);
        }
    }
    

    IEnumerator Phasing(float spawnTime)
    {
        Coroutine a = StartCoroutine("Phase1", spawnTime);
        Coroutine b = StartCoroutine("Phase2", spawnTime);
        Coroutine c = StartCoroutine("Phase3", spawnTime);

        yield return a;
        yield return b;
        yield return c;
    }
}
