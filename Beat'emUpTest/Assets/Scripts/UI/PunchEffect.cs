using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchEffect : MonoBehaviour
{
    [HideInInspector]
    public SpriteRenderer sr;


    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;
    }

    //void Update()
    //{
    //    sr.enabled = false;
    //}
}
