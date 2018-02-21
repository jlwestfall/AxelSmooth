using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidingSwitch : MonoBehaviour 
{
	public bool inRange;

	// Use this for initialization
	void Start () 
	{
		inRange = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "HitBox")
			inRange = true;
		else
			inRange = false;
	}
}
