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
    AudioController audioController;

    GameObject hitEffect;

    void Start()
    {
        audioController = GameManager.gm.audioController.GetComponent<AudioController>();
        hitEffect = this.gameObject.transform.GetChild(0).gameObject;
    }


    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.transform.root.tag == "Enemy" &&
            other.gameObject.transform.root.GetComponent<EnemyActions>().isStunned == false &&
            other.gameObject.transform.root.GetComponent<HitBoxDamage>().isDead == false)
        {
            anim = other.gameObject.transform.root.GetComponent<Animator>();

            KnockBack(knockBackVerticalForce, knockBackHorizontalForce, other.transform.root.gameObject);
            audioController.audioSource.PlayOneShot(audioController.punch, .5f);

            hitEffect.GetComponent<SpriteRenderer>().enabled = true;

        }
        else hitEffect.GetComponent<SpriteRenderer>().enabled = false;
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

    public void ToggleSprite()
    {
        hitEffect.GetComponent<SpriteRenderer>().enabled = !hitEffect.GetComponent<SpriteRenderer>().enabled;
    }
}
