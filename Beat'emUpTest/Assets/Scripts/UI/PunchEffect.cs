using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchEffect : MonoBehaviour
{
    [HideInInspector]
    public SpriteRenderer sr;

    public GameObject explosion;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;
    }

    public IEnumerator ToggleSprite()
    {
        explosion.GetComponent<SpriteRenderer>().enabled = !explosion.GetComponent<SpriteRenderer>().enabled;
        yield return new WaitForSeconds(0.2f);
        explosion.GetComponent<SpriteRenderer>().enabled = false;

    }

    public void ToggleExplosion()
    {
        StartCoroutine(ToggleSprite());
    }
}
