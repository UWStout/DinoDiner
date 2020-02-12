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
    // public GameManager gameManager;

    private float BigCook;
    private float SmallCook;
    private float BigTimer;
    private float SmallTimer;
    private bool BigStart;
    private bool SmallStart;



    // Use this for initialization
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        speed = 2.0f;
        //anim = GetComponent<Animator>();
        BigCook = 0;
        SmallCook = 0;
        BigTimer = 0;
        SmallTimer = 0;
        BigStart = false;
    }


    // Update is called once per frame
    void Update()
    {

        CheckInput();

        if (BigStart == true && BigTimer < 7)
        {
            BigTimer += Time.deltaTime;
        }
        if (SmallStart == true && SmallTimer < 3)
        {
            SmallTimer += Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            print(SmallCook + "Small cook");
            print(BigCook + " big cook");
        }

        if (BigTimer > 7)
        {
            print("big is done");
        }
        if (SmallTimer > 3)
        {
            print("small is done");
        }
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

        rb2D.velocity = new Vector2(velx, vely);
    }

   
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "BigTrigger")
        {
            if (Input.GetKeyDown(KeyCode.E) && BigTimer >= 7)
            {
                BigCook += 1;
                BigTimer = 0;
                print(BigCook + "big cookie amount is this");
                BigStart = false;
            }
            else if (Input.GetKeyDown(KeyCode.E) && BigTimer == 0)
            {
                BigStart = true;
            }
            
        }
        else if (collision.gameObject.name == "SmallTrigger")
        {

            if (Input.GetKeyDown(KeyCode.E) && SmallTimer >= 3)
            {
                SmallCook += 1;
                SmallTimer = 0;
                print(SmallCook + "Small cookies count is this");
                SmallStart = false;
            }
            else if (Input.GetKeyDown(KeyCode.E) && SmallTimer == 0)
            {
                SmallStart = true;
            }

        }
        else if (collision.gameObject.tag == "BigPellet")
        {
            collision.gameObject.SetActive(false);

        }

    }

}
