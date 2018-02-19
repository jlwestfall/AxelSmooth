using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetHealthMeter : MonoBehaviour
{
    [SerializeField]
    private float fillAmount;
    [SerializeField]
    private Image content;

    private float maxHealth;
    private float curHealth;
}
