using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour 
{
	public float scrollSpeed;
	public float tileWidth;

	private Vector3 startPosition;

	// Use this for initialization
	void Start () 
	{
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileWidth);
		transform.position = startPosition + Vector3.left * newPosition;
	}
}
