using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    public float interPVelocity;
    public float minDistance;
    public float followDistance;
    public bool following;
    public Vector3 offset;

    Vector3 targetPos;
	GameObject target;
    GameObject playerFollow1;
    GameObject playerFollow2;

    void Start()
    {
        targetPos = transform.position;
        offset = new Vector3(0, .59f, 0);
        following = false;

        playerFollow1 = GameManager.gm.player;
        playerFollow2 = GameManager.gm.player2;
    }

    void FixedUpdate()
    {
        if (playerFollow1.transform.position.x > playerFollow2.transform.position.x)
            target = playerFollow1;
        else if (playerFollow2.transform.position.x > playerFollow1.transform.position.x)
            target = playerFollow2;

        if (target && following)
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
