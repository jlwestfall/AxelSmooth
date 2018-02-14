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
    PlayerController playerController;
    GameObject playerObject;

    public List<GameObject> PlayersInGame = new List<GameObject>();
    public List<GameObject> EnemiesInGame = new List<GameObject>();
    //public List<GameObject> SpawnPhases = new List<GameObject>();

    SpawnManager spawnManager;

    SmoothCameraFollow smoothCamera;
    public Camera camera;


    public int enemiesKilledInPhase;
    public bool phase1, phase2, phase3, phase4, phase5 = false;

    private int phaseCounter = 1;

    void Start()
    {
        levelPhase = LevelPhase.PHASE1;
        playerObject = GameManager.gm.player.gameObject;
        playerController = GameManager.gm.player.GetComponent<PlayerController>();
        //EnemiesInGame.AddRange(GameObject.FindGameObjectsWithTag("Zombie"));
        PlayersInGame.AddRange(GameObject.FindGameObjectsWithTag("Player"));
        spawnManager = GameManager.gm.spawnManager.GetComponent<SpawnManager>();
        smoothCamera = camera.GetComponent<SmoothCameraFollow>();
    }

    void Update()
    {
        switch (levelPhase)
        {
            case (LevelPhase.PHASE1):
                playerController.xMin = -38f;
                playerController.xMax = -27f;
                smoothCamera.following = false;
                spawnManager.phase1 = true;

                if (enemiesKilledInPhase >= 1)
                {
                    spawnManager.phase1 = false;
                    if (EnemiesInGame.Count == 0)
                    {
                        enemiesKilledInPhase = 0;
                        levelPhase = LevelPhase.CONTINUE;
                    }
                }
                break;

            case (LevelPhase.PHASE2):
                playerController.xMin = -16f;
                playerController.xMax = -4f;
                smoothCamera.following = false;

                spawnManager.phase2 = true;

                if (enemiesKilledInPhase >= 1)
                {
                    spawnManager.phase2 = false;
                    if (EnemiesInGame.Count == 0)
                    {
                        enemiesKilledInPhase = 0;
                        levelPhase = LevelPhase.CONTINUE;
                    }
                }
                break;

            case (LevelPhase.PHASE3):
                playerController.xMin = 13f;
                playerController.xMax = 25f;
                smoothCamera.following = false;

                spawnManager.phase3 = true;

                if (enemiesKilledInPhase >= 1)
                {
                    spawnManager.phase2 = false;
                    if (EnemiesInGame.Count == 0)
                    {
                        enemiesKilledInPhase = 0;
                        levelPhase = LevelPhase.CONTINUE;
                    }
                }
                break;


            case (LevelPhase.CONTINUE):
                //playerController.xMax = -9f;
                smoothCamera.following = true;


                //Phase1 Cont to Phase2
                if (playerObject.transform.position.x >= -10 && phaseCounter == 1)
                {
                    phaseCounter++;
                    levelPhase = LevelPhase.PHASE2;
                }
                else if (playerObject.transform.position.x < -10 && phaseCounter == 1)
                    playerController.xMax = -9;

                //Phase2 Cont to
                else if (playerObject.transform.position.x >= 20 && phaseCounter == 2)
                {

                    phaseCounter++;
                    levelPhase = LevelPhase.PHASE3;
                }
                else if (playerObject.transform.position.x < 20 && phaseCounter == 2)
                    playerController.xMax = 21;

                break;
        }


    }

  
}
