using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCleanUp : MonoBehaviour 
{

	private float time = 5f;
	

	void Update () 
	{
		time -= Time.deltaTime;

		if(time <= 0)
			Destroy(this.gameObject);
	}

	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.tag == "HitBox")
			Destroy(this.gameObject);
	}

	
}
