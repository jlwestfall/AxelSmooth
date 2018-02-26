using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetHealthMeter : MonoBehaviour
{
    [SerializeField]
    Image content;
    GameObject enemTargetObject;

    float maxHealth = 100;
    float curHealth = 10;

    void Start()
    {
        
    }

    void Update()
    {
        HandleBar();
    }

    private void HandleBar()
    {
        content.fillAmount = Map(curHealth, 0, maxHealth, 0, 1);
    }

    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
