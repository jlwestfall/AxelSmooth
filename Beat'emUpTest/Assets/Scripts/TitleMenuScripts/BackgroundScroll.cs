using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour {
	public Element type;
	public Material source;
	public float scrollSpeed;
	float i = 0;
	public float floatSpeed;
	public float resetPoint;
	public float resetNewPoint;
	public float maxHeight;
	public bool movingUp;
	Vector3 lowLimit;
	Vector3 heightLimit;
	public enum Element{
		FLOATING,SCROLLING,GLIDING
	}
	void Start () {
		lowLimit = transform.position;
		heightLimit = transform.position;
		heightLimit.y += maxHeight;
		if(type == Element.GLIDING){
			i = transform.position.x;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		
		

		if(type == Element.SCROLLING){
			i += scrollSpeed * Time.deltaTime;
			source.SetTextureOffset("_MainTex", new Vector2(i, 0));
		}

		if(type == Element.FLOATING){
			if(movingUp){
				transform.position = Vector3.MoveTowards(transform.position, heightLimit, floatSpeed * Time.deltaTime);
			}
			if(!movingUp){
				transform.position = Vector3.MoveTowards(transform.position, lowLimit, floatSpeed * Time.deltaTime);
			}

			if(transform.position.y >= heightLimit.y ){
				movingUp = false;
				
			}
			if(transform.position.y <= lowLimit.y){
				movingUp = true;
			}
		}
		if(type == Element.GLIDING){
			i -= scrollSpeed * Time.deltaTime;
			transform.position = new Vector3(i, transform.position.y, transform.position.z);

			if(i <= resetPoint){
				i = resetNewPoint;
			}
		}
		
	}
}
