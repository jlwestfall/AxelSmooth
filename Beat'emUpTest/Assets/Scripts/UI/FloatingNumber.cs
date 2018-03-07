using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingNumber : MonoBehaviour 
{
	// floating speed
	public float moveSpeed;
	public float timeToDestroy;
	public string sortingLayer;
	public string popUpNum;

	void Awake()
	{
		this.gameObject.GetComponent<MeshRenderer>().sortingLayerName = sortingLayer;
	}
	void Start()
	{
		GetComponent<TextMesh>().text = popUpNum;
	}

	void Update()
	{	
		timeToDestroy -= Time.deltaTime;

		if(timeToDestroy <= 0)
			Destroy(this.gameObject);
		else
			this.transform.position = new Vector3(transform.position.x, transform.position.y + (moveSpeed * Time.deltaTime), transform.position.z);
	}

}
