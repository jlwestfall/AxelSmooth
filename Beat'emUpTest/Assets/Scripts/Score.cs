using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour 
{

	public int score;
	public string scoreString;

	public Text scoreText;


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		Debug.Log(score);
		scoreString = score.ToString();
		scoreText.text =  scoreString;
	}
}
