using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public int scoreP1;
    //public int scoreP2;
    public string scoreString;

    public Text scoreTextP1;
    public Text scoreTextP2;


    void Update()
    {

        scoreString = scoreP1.ToString();
        scoreTextP1.text = scoreString;


    }
}
