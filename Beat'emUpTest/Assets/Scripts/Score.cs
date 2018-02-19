using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour 
{

	public int scoreP1;
	public int scoreP2;
	public string scoreString;
	
	public Text scoreText;

	void Start()
	{
		
	}

	void Update () 
	{
		if(this.gameObject.name == "PlayerScore1")
		{
			scoreString = scoreP1.ToString();
			scoreText.text = scoreString;
		}
		else if(this.gameObject.name == "PlayerScore2")
		{
			scoreString = scoreP2.ToString();
			scoreText.text = scoreString;
		}
	}
}
