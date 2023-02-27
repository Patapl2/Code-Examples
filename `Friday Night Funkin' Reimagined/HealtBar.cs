using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtBar : MonoBehaviour
{
    Vector3 localScale;
    void Start()
    {
        localScale = transform.localScale;
    }
     
    //A script that handles the display of the healthbar UI element, scaling the bar depending on the health number.
    void Update()
    {
        localScale.x = PlayerStats.PlayerHP;
        transform.localScale = localScale;
    }
}
