using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour 
{

	public int scoreP1;
	public int scoreP2;
	public string scoreString;
	
	public Text scoreTextP1;
	public Text scoreTextP2;

	void Start()
	{
		
	}

	void Update () 
	{
		if(this.gameObject.name == "PlayerScore1")
		{
			scoreString = scoreP1.ToString();
			scoreTextP1.text = scoreString;
		}
		else if(this.gameObject.name == "PlayerScore2")
		{
			scoreString = scoreP2.ToString();
			scoreTextP2.text = scoreString;
		}
	}
}
