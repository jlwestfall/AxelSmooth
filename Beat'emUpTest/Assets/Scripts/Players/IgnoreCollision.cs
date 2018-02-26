using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{

	GameObject playerOne;
	GameObject playerTwo;
	
    void Start()
    {
		playerOne = GameManager.gm.player;
		playerTwo = GameManager.gm.player2;

		Physics.IgnoreCollision(playerOne.GetComponent<Collider>(), playerTwo.GetComponent<Collider>());
    }
}
