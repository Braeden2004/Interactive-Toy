using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemLogic : MonoBehaviour
{
    public float speed = 10.0f; // adjust as needed
    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {



        //Switch gravity with spacebar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (rb.gravityScale > 0)
            {
                rb.gravityScale = -10;
            }
            else
            {
                rb.gravityScale = 10;
            }
        }

    }
}
