using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CollidingSwitch : MonoBehaviour
{
    public bool inRange;
    public GameObject enemy;

    NavMeshAgent navMeshAgent;


    // Use this for initialization
    void Start()
    {
        navMeshAgent = enemy.GetComponent<NavMeshAgent>();
        inRange = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HitBox")
        {
            inRange = true;
            navMeshAgent.enabled = false;
        }
        else
        {
            inRange = false;
            navMeshAgent.enabled = true;
        }


    }
}
