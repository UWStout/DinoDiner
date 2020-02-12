using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb2D;
   // private Animator anim;
    private float speed;
    private float velx;
    private float vely;
    private float friction;
    private float changespeed;
   // public GameManager gameManager;



    // Use this for initialization
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        speed = 3.0f;
        friction = .8f;
        changespeed = 1f;
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        CheckInput();

     }

    //gets player input
    void CheckInput()
    {
        if (Input.GetAxisRaw("Vertical") > 0)
        {
           

            vely += changespeed;
            if (vely > speed)
            {
                if (vely < 0)
                {
                    vely = 0;
                }
                vely = speed;
                
            }
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
            {
            vely -= changespeed;
            if (vely < -speed)
            {
                if (vely > 0)
                {
                    vely = 0;
                }
                vely = -speed;
            }
        }
        else
        {
            vely = 0;
        }

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            velx += changespeed;
            if (velx > speed)
            {
                if (velx < 0)
                {
                    velx = 0;
                }
                velx = speed;
            }
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            velx -= changespeed;
            if (velx < -speed)
            {
                if (velx > 0)
                {
                  velx = 0;
                }
                velx = -speed;
            }
        }

        //do the angle between velx and vely

       //Vector2.Angle((velx,0.0f), vely);


        rb2D.AddForce(new Vector2(velx, vely));
        print("velx" + velx);
        print("vely" + vely);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "ExitLeft")
        {
            transform.position = new Vector2(13.5f, -0.5f);
        }
        else if (collision.gameObject.name == "ExitRight")
        {
            transform.position = new Vector2(-13.5f, -0.5f);
        }
        else if (collision.gameObject.tag == "SmallPellet")
        {
        }
        else if (collision.gameObject.tag == "BigPellet")
        {
            collision.gameObject.SetActive(false);
        }

    }



}
