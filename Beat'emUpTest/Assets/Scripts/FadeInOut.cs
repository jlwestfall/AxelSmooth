using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour {

	public Image faderPlane;
	float alpha = 1;
	public float fadeInSpeed;
	public float fadeOutSpeed;
	Color targetColor;
	public bool fadeIn;
	public AudioSource source;
	float originalVolume;
	public string sceneToLoad;
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(GameManager.gm.player.GetComponent<Player>().curHealth <= 0){
			fadeIn = false;
		}
		if(!fadeIn && alpha >= 1)
			SceneManager.LoadScene(sceneToLoad);

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
			alpha += fadeOutSpeed * Time.deltaTime;
		}
		source.volume = (originalVolume - alpha);
	}
}
