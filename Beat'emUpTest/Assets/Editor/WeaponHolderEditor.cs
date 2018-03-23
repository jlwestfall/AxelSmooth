using UnityEngine;
using UnityEditor;
using System.Collections;
[CustomEditor(typeof(WeaponHolder))]

public class WeaponHolderEditor : Editor {
	
	
	public AnimationState currentState;
	 static void Init()
    {
    
    }

	public override void OnInspectorGUI(){
		base.OnInspectorGUI();
		
		
		WeaponHolder holderScript = (WeaponHolder)target;
		
		if(holderScript.transform.parent.tag != "Player"){
			EditorGUILayout.HelpBox("This weapon holder is not connected to a player!", MessageType.Error);
		}
		if(holderScript.playerSprite == null){
			EditorGUILayout.HelpBox("The player [Sprite Renderer] required is missing!", MessageType.Warning);
		}

		if(holderScript.idleSprites.Length != holderScript.idlePosRot.Length){
			EditorGUILayout.HelpBox("The list of idle sprites in the array does not match requirements! [Uses " + holderScript.idlePosRot.Length + " sprites]", MessageType.Warning);
		}
		if(holderScript.attackSprites.Length != holderScript.swingPosRot.Length){
			EditorGUILayout.HelpBox("The list of attack sprites in the array does not match requirements! [Uses " + holderScript.swingPosRot + " sprites]", MessageType.Warning);
		}
		if(holderScript.stunSprites.Length != holderScript.stunPosRot.Length){
			EditorGUILayout.HelpBox("The list of stun sprites in the array does not match requirements! [Uses " + holderScript.stunPosRot.Length + " sprites]", MessageType.Warning);
		}
		if(holderScript.deadSprites.Length != holderScript.deadPosRot.Length){
			EditorGUILayout.HelpBox("The list of death sprites in the array does not match requirements! [Uses " + holderScript.deadPosRot.Length + " sprites]", MessageType.Warning);
		}
		if(holderScript.walkSprites.Length != holderScript.walkPosRots.Length){
			EditorGUILayout.HelpBox("The list of walk sprites in the array does not match requirements! [Uses " + holderScript.walkPosRots.Length + " sprites]", MessageType.Warning);
		}

		if(holderScript.weaponSprites.Length <= 0){
			EditorGUILayout.HelpBox("The weapon array must have at least one sprite!", MessageType.Warning);
		}
		
		GUILayout.BeginHorizontal();		
		if(GUILayout.Button("CHANGE FOCUSED ANIMATION")){
			switch(holderScript.weaponState){
				case(WeaponHolder.WeaponAnimation.IDLE): holderScript.currentlyEditing = holderScript.idlePosRot; holderScript.stringState = "Idle";
				break;
				case(WeaponHolder.WeaponAnimation.ATTACK):holderScript.currentlyEditing = holderScript.swingPosRot; holderScript.stringState = "Attack";
				break;
				case(WeaponHolder.WeaponAnimation.WALK): holderScript.currentlyEditing = holderScript.walkPosRots; holderScript.stringState = "Walk";
				break;
				case(WeaponHolder.WeaponAnimation.STUN): holderScript.currentlyEditing = holderScript.stunPosRot; holderScript.stringState = "Stun";
				break;
				case(WeaponHolder.WeaponAnimation.DEATH): holderScript.currentlyEditing = holderScript.deadPosRot; holderScript.stringState = "Death";
				break;
			}

			holderScript.index = 0;
			Preview(holderScript, holderScript.index);	
			ChangeSprite(holderScript.index, holderScript);
			
		}
		
		GUILayout.EndHorizontal();
	
		
		
		EditorGUILayout.LabelField("Current Animation: " + holderScript.stringState + " (Frame " + + (holderScript.index + 1) +"/" + (holderScript.currentlyEditing.Length) + ")");
		GUILayout.BeginHorizontal();
		
		
		if(GUILayout.Button("< Previous Frame")){

			if((holderScript.index - 1) >= 0){
				holderScript.index -= 1;
			}else{
				holderScript.index = holderScript.currentlyEditing.Length - 1;
			}
			Preview(holderScript, holderScript.index);	
			ChangeSprite(holderScript.index, holderScript);
		}
		
		if(GUILayout.Button("Next Frame >")){
			Debug.Log("Hit button!");
			if((holderScript.index + 1) <= holderScript.currentlyEditing.Length - 1){
				holderScript.index += 1;
			}else{
				holderScript.index = 0;
			}
			Preview(holderScript, holderScript.index);	
			ChangeSprite(holderScript.index, holderScript);
		}	
		
		GUILayout.EndHorizontal();
		if(GUILayout.Button("Preview/Reset")){
			
		Preview(holderScript, holderScript.index);	
		ChangeSprite(holderScript.index, holderScript);
		}
		if(GUILayout.Button("Assign Position")){
			Assign(holderScript, holderScript.index);	
		}
		
		
		
		
		GUILayout.BeginHorizontal();
		if(GUILayout.Button("< Previous Weapon")){
			if(holderScript.spriteIndex - 1 >= 0){
				holderScript.spriteIndex -= 1;
			}else{
				holderScript.spriteIndex = holderScript.weaponSprites.Length - 1;
			}	
			holderScript.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = holderScript.weaponSprites[holderScript.spriteIndex];
		}
		if(GUILayout.Button("Next Weapon >")){
			if(holderScript.spriteIndex + 1 <= holderScript.weaponSprites.Length - 1){
				holderScript.spriteIndex += 1;
			}else{
				holderScript.spriteIndex = 0;
			}
			holderScript.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = holderScript.weaponSprites[holderScript.spriteIndex];		
		}

		GUILayout.EndHorizontal();
		
		
		
		
		
		
	}

	public void Preview(WeaponHolder holderScript, int index){	
		holderScript.gameObject.transform.localPosition = new Vector3(holderScript.currentlyEditing[holderScript.index].x, holderScript.currentlyEditing[holderScript.index].y, 0);
		holderScript.gameObject.transform.localEulerAngles = new Vector3(0, 0, holderScript.currentlyEditing[holderScript.index].z);
	}

	public void Assign(WeaponHolder holderScript, int index){
		if(EditorUtility.DisplayDialog("Assign New Frame Position", "Are you sure you want to change the weapon's position on frame " + (holderScript.index + 1) + " of the animation " + holderScript.stringState + " ?", "Assign", "Cancel")){
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
				case(WeaponHolder.WeaponAnimation.STUN): 
				holderScript.stunPosRot[holderScript.index] = new Vector3(holderScript.gameObject.transform.localPosition.x, 
																			holderScript.gameObject.transform.localPosition.y,
																			holderScript.gameObject.transform.localEulerAngles.z);
				break;

				case(WeaponHolder.WeaponAnimation.DEATH): 
				holderScript.deadPosRot[holderScript.index] = new Vector3(holderScript.gameObject.transform.localPosition.x, 
																			holderScript.gameObject.transform.localPosition.y,
																			holderScript.gameObject.transform.localEulerAngles.z);
				break;
			}
				}
		
		
	}

	public void ChangeSprite(int index, WeaponHolder holderScript){
		
		switch(holderScript.weaponState){
				case(WeaponHolder.WeaponAnimation.IDLE): holderScript.playerSprite.sprite = holderScript.idleSprites[index];
				break;
				case(WeaponHolder.WeaponAnimation.ATTACK): holderScript.playerSprite.sprite = holderScript.attackSprites[index];
				break;
				case(WeaponHolder.WeaponAnimation.WALK): holderScript.playerSprite.sprite = holderScript.walkSprites[index];
				break;
				case(WeaponHolder.WeaponAnimation.STUN): holderScript.playerSprite.sprite = holderScript.stunSprites[index];
				break;
				case(WeaponHolder.WeaponAnimation.DEATH): holderScript.playerSprite.sprite = holderScript.deadSprites[index];
				break;
		}

	
		
	}
}
