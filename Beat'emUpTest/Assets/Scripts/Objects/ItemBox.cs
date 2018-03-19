using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public GameObject[] itemPickups;

    Animator animator;
    AudioController audioController;
    int attackCount;
    bool flip;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioController = GameManager.gm.audioController.GetComponent<AudioController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hit")
        {
            GameObject player;
            PlayerController playerController;

            player = other.gameObject.transform.parent.gameObject;
            playerController = player.GetComponent<PlayerController>();
        
            audioController.audioSource.PlayOneShot(audioController.crateHit, .5f);
            attackCount++;

            if (attackCount == 3)
            {
                if (!playerController.facingRight)
                {
                    Vector3 thisScale = transform.localScale;
                    thisScale.x *= -1;
                    transform.localScale = thisScale;
                }
                animator.SetTrigger("BrokenBox");
            }
        }
    }

    public void DestroyBox()
    {
        Destroy(this.gameObject);
    }

    public void SpawnItem()
    {
        Vector3 itemSpawnLocation;
        itemSpawnLocation = new Vector3(transform.position.x, transform.position.y - 2, transform.position.z);
        Instantiate(itemPickups[0], itemSpawnLocation, transform.rotation);
    }
}
