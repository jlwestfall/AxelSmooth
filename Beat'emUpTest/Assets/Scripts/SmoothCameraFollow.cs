using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
	public float interPVelocity;
	public float minDistance;
	public float followDistance;
	public bool following;
	public GameObject target;
	public Vector3 offset;
	
	Vector3 targetPos;

	void Start()
	{
		targetPos = transform.position;
		offset = new Vector3(0,.59f,0);
		following = false;
	}

	void FixedUpdate()
	{
		if(target && following)
		{
			//LevelManager levelManager;
			//levelManager = GameManager.gm.levelManager.GetComponent<LevelManager>();

			
			
			Vector3 posNoZ = transform.position;

			posNoZ.z = target.transform.position.z;

			Vector3 targetDirection = (target.transform.position - posNoZ);

			interPVelocity = targetDirection.magnitude * 5f;

			targetPos = transform.position + (targetDirection.normalized * interPVelocity * Time.deltaTime);

			transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.5f);
		}
	}
}
