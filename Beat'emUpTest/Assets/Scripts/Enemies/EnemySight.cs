using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour 
{
	public bool playerInSight;
	
    void OnTriggerStay(Collider other)
	{
		if(other.gameObject.tag == "Player")
			playerInSight = true;
	}

	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.tag == "Player")
			playerInSight = false;
	}
}
