using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    //Define Variables
    public float moveSpeed = 10; // adjust speed 

    //Timer
    public float punchTime = 0.3f;
    public float punchTimeMax = 0.3f;
    bool punch = false;

    //Component variables
    public SpriteRenderer sr;
    public Rigidbody2D rb;

    //Setup Sprites
    public Sprite peterStand;
    public Sprite peterKick;


    void Start()
    {
        //Get the components
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        //Set up initial sprite
        sr.sprite = peterStand;
    }

    void Update()
    {
        //Move Right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }

        //Move Left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }

        //Track Spacebar Press
        if (Input.GetKeyDown(KeyCode.Space))
        {      
            punch = true;        
        }


        //Changing sprite with a timer
        if ((punch == true) && (punchTime > 0))
        {
            sr.sprite = peterKick;
            punchTime -= Time.deltaTime;
        }
        else
        {
            sr.sprite = peterStand;

            punch = false;
            punchTime = punchTimeMax;
        }

    }
}
