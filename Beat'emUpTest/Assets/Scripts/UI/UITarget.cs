using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITarget : MonoBehaviour
{
    public GameObject targetHealthPanel;

    public GameObject target;

    void Update()
    {
        if (target)
            targetHealthPanel.SetActive(true);
        else
            targetHealthPanel.SetActive(false);
    }


}
