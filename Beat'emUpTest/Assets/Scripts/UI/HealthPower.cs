using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPower : MonoBehaviour
{
    public enum PlayerChoice
    {
        PLAYER1, PLAYER2
    }

    public PlayerChoice playerChoice;

    [SerializeField]
    private float fillAmount;
    [SerializeField]
    private Image content;

    private Player player;

    public float maxHealth;
    public float curHealth;
    public float maxPower;
    public float curPower;


    // Use this for initialization
    void Start()
    {
        

        switch (playerChoice)
        {
            case (PlayerChoice.PLAYER1):
                player = GameManager.gm.player.GetComponent<Player>();
                break;
            case (PlayerChoice.PLAYER2):
                player = GameManager.gm.player2.GetComponent<Player>();
                break;
        }
        player.powerScript.gameObject.SetActive(false);
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
