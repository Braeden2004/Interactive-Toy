using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    //Define Variables
    public float moveSpeed = 10; // adjust speed 
    public float power = 10000;
    private float powerDefault = 10000;

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
    public Sprite peterPajamaStand;
    public Sprite peterPajamaSwing;

    //Powerup
    public bool powerUp = false;


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
            //Change Sprite depending on if he has a power up
            if (powerUp == false)
            {
                sr.sprite = peterKick;
                power = powerDefault;
            }
            
            if (powerUp == true) 
            {
                sr.sprite = peterPajamaSwing;
                power = 500000;

            }
            punchTime -= Time.deltaTime;
        }
        else
        {
            if (powerUp == false) sr.sprite = peterStand;
            if (powerUp == true) sr.sprite = peterPajamaStand;

            punch = false;
            punchTime = punchTimeMax;
        }
    }

    //Destroying object when hits lava
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("item"))
        {
            powerUp = true;

            Destroy(collision.gameObject);
        }
    }
}
