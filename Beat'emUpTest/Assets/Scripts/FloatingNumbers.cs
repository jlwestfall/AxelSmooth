using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingNumbers : MonoBehaviour
{

    public float moveSpeed;

    //public MeshRenderer mr;


    void Start()
    {
        GetComponent<TextMesh>().text = "200";
        //mr = GetComponent<TextMesh>();
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + (moveSpeed * Time.deltaTime), transform.position.z);
    }


}

