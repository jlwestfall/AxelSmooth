using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingNumbers : MonoBehaviour 
{

	private float moveSpeed;
	public int scoreNum;
	public Text displayNum;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update()
	{
		displayNum.text = "" + scoreNum;
	}
}
