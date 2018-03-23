using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {
	public float delay;
	public Text countDownText;
	public float countdownTime;
	float timer;
	public string titleScreenName;
	public string mainGameName;
	public bool input;
	public bool delayFinished;
	public float screenChangeDelay;
	public float inputTime;
	void Start () {
		inputTime = -1000;
	}
	
	// Update is called once per frame
	void Update () {

		delayFinished = Delay(delay);
		if(delayFinished == true){
			countdownTime -= 1 * Time.deltaTime;
			CountDown(countdownTime);
			countDownText.color = new Color(1, 1, 1, 1f);
		}else{
			countDownText.color = new Color(1, 1, 1, 0.2f);
		}
		if(countdownTime <= 0){
			countDownText.enabled = false;
		}
			

		if(Input.GetKeyDown(KeyCode.Space) && countdownTime > 0){
			input = true;
			inputTime = countdownTime;
		}

		if(countdownTime < -screenChangeDelay && !input){
			SceneManager.LoadScene(titleScreenName);
		}
		if(countdownTime < (inputTime - screenChangeDelay)){
			SceneManager.LoadScene(mainGameName);
		}

		
	}

	public void CountDown(float seconds){
		countDownText.text = "" + Mathf.Round(seconds) + " SECONDS LEFT";
	}

	public bool Delay(float seconds){
		delay -= 1 * Time.deltaTime;
		if(seconds <= 0){
			return true;
		}else{
			return false;
		}
	}
}
