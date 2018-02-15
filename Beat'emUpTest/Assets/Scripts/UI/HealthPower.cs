using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPower : MonoBehaviour
{
    [SerializeField]
    private float fillAmount;
    [SerializeField]
    private Image content;

    private Player player;

    private float maxHealth;
    private float curHealth;
    private float maxPower;
    private float curPower;

    // Use this for initialization
    void Start()
    {
        player = GameManager.gm.player.GetComponent<Player>();




    }

    // Update is called once per frame
    void Update()
    {
        HandleBar();

        maxHealth = player.maxHealth;
        curHealth = player.curHealth;

        maxPower = player.maxPower;
        curPower = player.curPower;
    }

    private void HandleBar()
    {
        if (this.gameObject.tag == "Health")
            content.fillAmount = Map(curHealth, 0, maxHealth, 0, 1);
        if (this.gameObject.tag == "Power")
            content.fillAmount = Map(curPower, 0, maxPower, 0, 1);
    }

    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
