using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour 
{

	public int score;
	public string scoreString;

	public Text scoreText;


	void Update () 
	{
		scoreString = score.ToString();
		scoreText.text =  scoreString;
	}
}
