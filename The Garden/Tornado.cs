using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour
{
    public bool isTornadoTriggered = false;
    private Rigidbody rb;

    //Physics behind the tornado that the player can interact with to ascend and boost their jump.
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isTornadoTriggered == true)
        {
            rb.AddForce(0,10f,0);
            rb.mass = 0.75f;
        }
    }

    void OnTriggerEnter(Collider tornado)
    {
        if (tornado.gameObject.tag == "Tornado")
        {
            isTornadoTriggered = true;
        }
    }
    void OnTriggerExit(Collider tornado)
    {
        isTornadoTriggered = false;
        rb.mass = 1.5f;
    }

    
}
