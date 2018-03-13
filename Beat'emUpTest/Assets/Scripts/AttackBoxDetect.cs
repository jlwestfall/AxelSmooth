using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBoxDetect : MonoBehaviour
{
    [Header("Basic Knockback")]
    [Range(0, 3)]
    public float knockBackVerticalForce;
    [Range(0, 3)]
    public float knockBackHorizontalForce;
    [Header("Strong Knockback")]
    [Range(0, 101)]
    public int StrongHitChance;
    [Range(0, 3)]
    public float strongHitMultiplier;
    Animator anim;
    AnimatorOverrideController overrideController;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && other.gameObject.GetComponent<EnemyActions>().isStunned == false)
        {
            anim = other.gameObject.GetComponent<Animator>();

            KnockBack(knockBackVerticalForce, knockBackHorizontalForce, other.gameObject);



        }
        print("hello");
    }

    public void KnockBack(float verticalForce, float horizontalForce, GameObject target)
    {
        target.GetComponent<EnemyActions>().isStunned = true;
        Rigidbody rb = target.GetComponent<Rigidbody>();
        Vector3 forceDir = Vector3.zero;
        int ran = Random.Range(0, 101);
        bool strongHit = false;

        float multiplier = strongHitMultiplier;
        if (ran <= StrongHitChance)
        {
            strongHit = true;
        }

        if (target.GetComponent<SpriteRenderer>().flipX)
            forceDir = Vector3.right;
        else
            forceDir = Vector3.left;       

        if (!strongHit)
        {
            multiplier = 1;
            anim.SetBool("Stunned", true);
        }
        else
            anim.SetBool("StunnedStrong", true);

        rb.AddForce(forceDir * horizontalForce * multiplier, ForceMode.Impulse);
        rb.AddForce(Vector3.up * verticalForce, ForceMode.Impulse);


    }
}
