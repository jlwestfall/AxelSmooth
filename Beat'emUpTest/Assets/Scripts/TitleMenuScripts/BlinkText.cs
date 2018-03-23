using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BlinkText : MonoBehaviour {

	Text thisText;
	public float showLength;
	public float hideLength;
	float timer;
	bool show = true;
	void Start () {
		thisText = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if(show)
			thisText.enabled = true;
		else
			thisText.enabled = false;

		if(timer > 0){
			timer -= 1 * Time.deltaTime;
		}else{
			if(show){
				timer = hideLength;
			}else{
				timer = showLength;
			}
			
			
			show = !show;
		}
	}
}
