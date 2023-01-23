using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityMovement : MonoBehaviour
{
    public float speed = 10f; // adjust as needed
    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);


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
