using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFloatNum : MonoBehaviour
{
    public float timeDestroy;

	void Start ()
    {
		
	}

	void Update ()
    {
        timeDestroy -= Time.deltaTime;

        if(timeDestroy <= 0)
        {
            Destroy(gameObject);
        }
	}
}
