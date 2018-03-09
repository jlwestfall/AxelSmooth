using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBoxDetect : MonoBehaviour {
	[Header("Basic Knockback")]
	[Range(0, 3)]
    public float knockBackVerticalForce;
    [Range(0, 10)]
    public float knockBackHorizontalForce;
	[Header("Strong Knockback")]
	[Range(0, 101)]
	public int StrongHitChance;
	[Range(0, 4)]
	public float strongHitMultiplier;
	Animator anim;
	AnimatorOverrideController overrideController;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.tag == "Enemy" && other.gameObject.GetComponent<EnemyActions>().isStunned == false){
			anim = other.gameObject.GetComponent<Animator>();

			KnockBack(knockBackVerticalForce, knockBackHorizontalForce, other.gameObject);
			
			
			
		}
		print("hello");
	}

	public void KnockBack(float verticalForce, float horizontalForce, GameObject target){
		target.GetComponent<EnemyActions>().isStunned = true;
		Rigidbody rb = target.GetComponent<Rigidbody>();
		Vector3 forceDir = Vector3.zero;
		float positionDirection = target.transform.position.x - gameObject.transform.position.x;
		int ran = Random.Range(0, 101);
		bool strongHit = false;

		float multiplier = strongHitMultiplier;
		if(ran <= StrongHitChance){
			strongHit = true;
		}

		if(positionDirection > 0){
			forceDir = Vector3.right;
		}else{
			forceDir = Vector3.left;
		}

		if(!strongHit){
			multiplier = 1;
			anim.SetBool("Stunned", true);
		}else{
			anim.SetBool("StrongStun", true);
		}
			
			rb.AddForce(forceDir * horizontalForce * multiplier, ForceMode.Impulse);
			rb.AddForce(Vector3.up * verticalForce, ForceMode.Impulse);

		
}
}
