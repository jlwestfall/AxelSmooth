using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject p1Panel;
    public GameObject p2Panel;
    public GameObject insertCoinP1;
    public GameObject insertCoinP2;

    GameObject player1;
    GameObject player2;
    // Use this for initialization

    void Start()
    {
        player1 = GameManager.gm.player;
        player2 = GameManager.gm.player2;
    }

    // Update is called once per frame
    void Update()
    {
        if (player1.active)
        {
            p1Panel.SetActive(true);
            insertCoinP1.SetActive(false);
        }
        else
        {
            p1Panel.SetActive(false);
            insertCoinP1.SetActive(true);
        }

        /*if (player2.active && player2 != null)
        {
            p2Panel.SetActive(true);
            insertCoinP2.SetActive(false);
        }
        else
        {
            p2Panel.SetActive(false);
            insertCoinP2.SetActive(true);
        }
        */
    }
}
