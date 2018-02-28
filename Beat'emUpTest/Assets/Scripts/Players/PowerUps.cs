using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    Player player;
    public GameObject textFloat;
    float r = 0.2f, g = 0.3f, b = 0.7f, a = 0.6f;


    void Start()
    {
        if (this.gameObject.name == "Player")
            player = GameManager.gm.player.GetComponent<Player>();
        if (this.gameObject.name == "Player2")
            player = GameManager.gm.player2.GetComponent<Player>();

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pizza" && player.curHealth < player.maxHealth)
        {
            player.curHealth += 200;
            textFloat.GetComponent<FloatingNumbers>().popUpNumber = "+HP200";
            textFloat.GetComponent<FloatingNumbers>().GetComponent<TextMesh>().color = new Color(0, 1, 0, 1);
            Instantiate(textFloat, transform.position, transform.rotation);


            if (player.curHealth > player.maxHealth)
                player.curHealth = player.maxHealth;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Beer" && this.gameObject.name == "Player")
        {
            GameManager.gm.score.scoreP1 += 200;
            textFloat.GetComponent<FloatingNumbers>().popUpNumber = "200";
            textFloat.GetComponent<FloatingNumbers>().GetComponent<TextMesh>().color = new Color(1, 0.92f, 0.016f, 1);
            Instantiate(textFloat, transform.position, transform.rotation);

            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Beer" && this.gameObject.name == "Player2")
        {
            GameManager.gm.score.scoreP2 += 200;
            textFloat.GetComponent<FloatingNumbers>().popUpNumber = "200";
            textFloat.GetComponent<FloatingNumbers>().GetComponent<TextMesh>().color = new Color(1, 0.92f, 0.016f, 1);
            Instantiate(textFloat, transform.position, transform.rotation);

            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "AmmoBox")
        {
            player.curPower += 100;
            textFloat.GetComponent<FloatingNumbers>().popUpNumber = "+PWR100";
            textFloat.GetComponent<FloatingNumbers>().GetComponent<TextMesh>().color = new Color(0, 1, 1, 1);
            Instantiate(textFloat, transform.position, transform.rotation);

            if (player.curPower > player.maxPower)
                player.curPower = player.maxPower;
            Destroy(other.gameObject);
        }
    }
}
