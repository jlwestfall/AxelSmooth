﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
	public static GameManager gm;
	[Header("Player Object")]
	public GameObject player;
	public Score score;
	[Header("Level Manager")]
	public GameObject levelManager;
	[Header("Spawn Manager")]
	public GameObject spawnManager;
	
	void Awake()
	{
		if(!gm)
			gm = this;
		else
			Destroy(this.gameObject);
	}
}
