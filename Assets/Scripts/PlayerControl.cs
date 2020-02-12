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

    private float BigCook;
    private float SmallCook;



    // Use this for initialization
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        speed = 3.0f;
        friction = .8f;
        //anim = GetComponent<Animator>();
        BigCook = 0;
        SmallCook = 0;
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
           

            vely += speed;

        }
        else if (Input.GetAxisRaw("Vertical") < 0)
            {
            vely -= speed;

        }
        else
        {
            vely = 0;
        }


        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            velx += speed;

        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            velx -= speed;

        }
        else
        {
            velx = 0;
        }

        //do the angle between velx and vely

       //Vector2.Angle((velx,0.0f), vely);


        rb2D.velocity = new Vector2(velx, vely);


    }

   
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Smalltrigger" && Input.GetKeyDown(KeyCode.E))
        {
            BigCook += 1;
        }
        else if (collision.gameObject.name == "BigTrigger" && Input.GetKeyDown(KeyCode.E))
        {
            SmallCook += 1;
        }

    }

}
