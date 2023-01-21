using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLogic : MonoBehaviour
{
    //Define Variables
    public GameObject attacker;
    public int power = 10000;

    //Getting Stunned
    public float stunTime = 0.5f;
    public float stunTimeMax = 0.5f;
    bool stun = false;

    //Component variables
    public SpriteRenderer sr;
    public Rigidbody2D rb;

    //Setup Sprites
    public Sprite chickStand;
    public Sprite chickHurt;

    void Start()
    {
        //Get the components
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        //Set up initial sprite
        sr.sprite = chickStand;
    }
    //* Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Calculate distance between Enemy and Player and apply it to "distance" variable
            float distance = Vector2.Distance(transform.position, attacker.transform.position);
            Debug.Log(distance);

            //If hit
            if (distance < 5f)
            {
                //Add Force
                rb.AddForce(new Vector2(power, power / 2));

                stun = true;
                Debug.Log("HIT");
            }
        }

        //Getting Stunned with a timer
        if ((stun == true) && (stunTime > 0))
        {
            //sr.color = new Color(1, 0, 0, 1);
            sr.sprite = chickHurt;

            stunTime -= Time.deltaTime;
        }
        else
        {
            sr.sprite = chickStand;

            stun = false;
            stunTime = stunTimeMax;
        }
        
    }


    //Destroying object when hits lava
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Lava"))
        {
            Destroy(gameObject);
        }
    }

}