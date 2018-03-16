using UnityEngine;
using UnityEditor;
using System.Collections;
[CustomEditor(typeof(WeaponHolder))]

public class WeaponHolderEditor : Editor {
	

	public AnimationState currentState;
	public override void OnInspectorGUI(){
		base.OnInspectorGUI();
		
		
		WeaponHolder holderScript = (WeaponHolder)target;
		
		
		
				
		if(GUILayout.Button("Change Currently Focused Animation")){
			switch(holderScript.weaponState){
				case(WeaponHolder.WeaponAnimation.IDLE): holderScript.currentlyEditing = holderScript.idlePosRot; holderScript.stringState = "Idle";
				break;
				case(WeaponHolder.WeaponAnimation.ATTACK):holderScript.currentlyEditing = holderScript.swingPosRot; holderScript.stringState = "Attack";
				break;
				case(WeaponHolder.WeaponAnimation.WALK): holderScript.currentlyEditing = holderScript.walkPosRots; holderScript.stringState = "Walk";
				break;
			}
			holderScript.index = 0;
			
		}
		EditorGUILayout.LabelField("Current Frame: " + holderScript.stringState);
		GUILayout.BeginHorizontal();
		if(GUILayout.Button("Previous Frame")){

			if((holderScript.index - 1) >= 0){
				holderScript.index -= 1;
			}else{
				holderScript.index = holderScript.currentlyEditing.Length - 1;
			}
			Preview(holderScript, holderScript.index);	
		}
		if(GUILayout.Button("Next Frame")){
			Debug.Log("Hit button!");
			if((holderScript.index + 1) <= holderScript.currentlyEditing.Length - 1){
				holderScript.index += 1;
			}else{
				holderScript.index = 0;
			}
			Preview(holderScript, holderScript.index);	
		}
		

		
		GUILayout.EndHorizontal();
		EditorGUILayout.LabelField("Current Frame: " + (holderScript.index + 1) +"/" + (holderScript.currentlyEditing.Length));
		if(GUILayout.Button("Preview")){
			
		Preview(holderScript, holderScript.index);	
	
		}
		if(GUILayout.Button("Assign")){
			Assign(holderScript, holderScript.index);	
		}
		GUILayout.BeginHorizontal();
		if(GUILayout.Button("Previous Sprite")){
			if(holderScript.spriteIndex - 1 >= 0){
				holderScript.spriteIndex -= 1;
			}else{
				holderScript.spriteIndex = holderScript.weaponSprites.Length - 1;
			}	
			holderScript.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = holderScript.weaponSprites[holderScript.spriteIndex];
		}
		if(GUILayout.Button("Next Sprite")){
			if(holderScript.spriteIndex + 1 <= holderScript.weaponSprites.Length - 1){
				holderScript.spriteIndex += 1;
			}else{
				holderScript.spriteIndex = 0;
			}
			holderScript.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = holderScript.weaponSprites[holderScript.spriteIndex];		
		}
		GUILayout.EndHorizontal();
		EditorGUILayout.LabelField("Current Sprite Number: " + holderScript.spriteIndex);
	}

	public void Preview(WeaponHolder holderScript, int index){	
		holderScript.gameObject.transform.localPosition = new Vector3(holderScript.currentlyEditing[holderScript.index].x, holderScript.currentlyEditing[holderScript.index].y, 0);
		holderScript.gameObject.transform.localEulerAngles = new Vector3(0, 0, holderScript.currentlyEditing[holderScript.index].z);
	}

	public void Assign(WeaponHolder holderScript, int index){
		switch(holderScript.weaponState){
				case(WeaponHolder.WeaponAnimation.IDLE): 
				holderScript.idlePosRot[holderScript.index] = new Vector3(holderScript.gameObject.transform.localPosition.x, 
																			holderScript.gameObject.transform.localPosition.y,
																			holderScript.gameObject.transform.localEulerAngles.z);
				break;
				case(WeaponHolder.WeaponAnimation.ATTACK): 
				holderScript.swingPosRot[holderScript.index] = new Vector3(holderScript.gameObject.transform.localPosition.x, 
																			holderScript.gameObject.transform.localPosition.y,
																			holderScript.gameObject.transform.localEulerAngles.z);
				break;
				case(WeaponHolder.WeaponAnimation.WALK): 
				holderScript.walkPosRots[holderScript.index] = new Vector3(holderScript.gameObject.transform.localPosition.x, 
																			holderScript.gameObject.transform.localPosition.y,
																			holderScript.gameObject.transform.localEulerAngles.z);
				break;
			}
		
	}
}
