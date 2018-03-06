using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnorePlayerCol : MonoBehaviour
{
	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "Player")
			Physics.IgnoreCollision(col.gameObject.GetComponent<Collider>(),GetComponent<Collider>());
	}
}
