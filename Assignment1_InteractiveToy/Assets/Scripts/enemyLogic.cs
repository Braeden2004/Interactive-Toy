using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLogic : MonoBehaviour
{
    //Define Variables
    public GameObject attacker;
    playerMove playerScript;
    //public int power = 10000; 

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

    //Audio Setup
    public AudioClip sfx_damage_hit5;
    public AudioClip sfx_coin_cluster9;

    private AudioSource audioSource;

    void Start()
    {
        //Get the components
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        //Set up initial sprite
        sr.sprite = chickStand;

        playerScript = GameObject.Find("player").GetComponent<playerMove>();
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
                rb.AddForce(new Vector2(playerScript.power, playerScript.power / 2));

                stun = true;
                Debug.Log("HIT");

                //Sound Effects
                if (playerScript.powerUp == false) PlayAttackSound();
                if (playerScript.powerUp == true) PlayPowerUpSound();
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

    //Restart game when chicken hits the barriers
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lava"))
        { 
            //Application.LoadLevel(0);
            Destroy(gameObject);
        }

    }

    private void PlayAttackSound()
    {
        audioSource.clip = sfx_damage_hit5;
        audioSource.Play();
    }

    private void PlayPowerUpSound()
    {

        audioSource.clip = sfx_coin_cluster9;
        audioSource.Play();
    }
}