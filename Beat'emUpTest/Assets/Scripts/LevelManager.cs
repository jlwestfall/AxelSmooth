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
        // -38 -27
        switch (levelPhase)
        {
            case (LevelPhase.PHASE1):
                playerController.xMin = -38f;
                playerController.xMax = -27f;
                smoothCamera.following = false;
                spawnManager.phase1 = true;

                if (enemiesKilledInPhase >= 2)
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

                if (enemiesKilledInPhase >= 6)
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

                if (playerObject.transform.position.x >= -10)
                {
                    levelPhase = LevelPhase.PHASE2;
                }
                else if (playerObject.transform.position.x <= -10)
                    playerController.xMax = -9f;
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
