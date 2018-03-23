﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour 
{
	public Image faderPlane;
	float alpha;
	public float fadeInSpeed;
	public float faceOutSpeed;
	Color targetColor;
	public bool fadeIn;
	public AudioSource source;
	float originalVolume;

	void Start() {
		alpha = 1;	
		originalVolume = source.volume;
	}
	void Update () 
	{
		if(Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.Joystick1Button0) && fadeIn && alpha <= 0){
			fadeIn = false;
		}
		if(!fadeIn && alpha >= 1)
			SceneManager.LoadScene("Main(TEST)");

		if(fadeIn){
			FadeIn();
		}else{
			FadeOut();
		}
		targetColor = new Color(0, 0, 0, alpha);
		faderPlane.color = targetColor;
	}
	public void FadeIn(){
		if(alpha > 0){
			alpha -= fadeInSpeed * Time.deltaTime;
		}
	}
	public void FadeOut(){
		if(alpha < 1){
			alpha += fadeInSpeed * Time.deltaTime;
		}
		source.volume = (originalVolume - alpha);
	}
}
