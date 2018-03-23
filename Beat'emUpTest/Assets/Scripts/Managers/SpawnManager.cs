using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float spawnTime = 15f;
    [Header("WavePoints 1")]
    public GameObject[] wavePoints1;
    [Header("Wave Points 2")]
    public GameObject[] wavePoints2;
    [Header("Wave Points 3")]
    public GameObject[] wavePoints3;
    [Header("Wave Points 4")]
    public GameObject[] wavePoints4;
    [Header("Wave Points 5")]
    public GameObject[] wavePoints5;

    public GameObject enemy;
    public GameObject goIcon;

    GameObject player;
    LevelManager levelManager;

    //Spawn Switches.
    public bool phase1, phase2, phase3, phase4, phase5 = false;


    void Start()
    {
        levelManager = GameManager.gm.levelManager.GetComponent<LevelManager>();
        player = GameManager.gm.player;
        phase1 = true;
        StartCoroutine("Phasing", spawnTime);
    }


    void Spawn(GameObject[] spawnPhase)
    {
        if (levelManager.EnemiesInGame.Count <= 4)
        {
            foreach (GameObject gO in spawnPhase)
            {
                Instantiate(enemy, gO.transform.position, gO.transform.rotation);
            }
        }
    }

    IEnumerator Phase1(float spawnTime)
    {
        yield return new WaitUntil(() => phase1);

        while (phase1)
        {
            if (player.transform.position.x < -33)
                goIcon.SetActive(true);
            else
                goIcon.SetActive(false);
            //Wave 1
            if (levelManager.EnemiesInGame.Count <= 0 && player.transform.position.x >= -31 )
            {
                Spawn(wavePoints1);
            }

            //Wave 2
            else if (levelManager.EnemiesInGame.Count <= 3 && levelManager.enemiesKilledInPhase >= 1)
            {
                Spawn(wavePoints2);
                yield return new WaitForSeconds(spawnTime);
                Spawn(wavePoints1);
            }

            //Wave 3
            else if (levelManager.EnemiesInGame.Count <= 3 && levelManager.enemiesKilledInPhase >= 3 && player.transform.position.x >= -11)
            {
                Spawn(wavePoints3);
            }

            yield return new WaitForSeconds(spawnTime);
        }

    }

    IEnumerator Phase2(float spawnTime)
    {
        yield return new WaitUntil(() => phase2);

        while (phase2)
        {
            Spawn(wavePoints2);
            yield return new WaitForSeconds(spawnTime);
        }
    }

    IEnumerator Phase3(float spawnTime)
    {
        yield return new WaitUntil(() => phase3);

        while (phase3)
        {
            Spawn(wavePoints3);
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
