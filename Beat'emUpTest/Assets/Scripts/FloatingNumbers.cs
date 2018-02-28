using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingNumbers : MonoBehaviour
{

    public float moveSpeed;
    public string popUpNumber;

    //public MeshRenderer mr;


    void Start()
    {
        GetComponent<TextMesh>().text = popUpNumber;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + (moveSpeed * Time.deltaTime), transform.position.z);
    }


}

