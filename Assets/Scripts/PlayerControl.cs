using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Vector2 movement;
    private SpriteRenderer sprite;
    // private Animator anim;
    private Vector2 speed;
    public GameManager gameManager;
    // private Animator anim;
    private float velx;
    private float vely;

    private float BigCook;
    private float SmallCook;
    private float BigTimer;
    private float SmallTimer;
    private bool BigStart;
    private bool SmallStart;

    public OvenScript bigOven;
    public OvenScript smallOven;

    public Vector3[] locations = new Vector3[5];
    private Vector3 temp = new Vector3();
    private Vector3 scale = new Vector3();

    // Use this for initialization
    void Start()
    {
        // if the GameManager is unbound in the editor, the below will bind it
       // gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();


        rb2D = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        BigCook = 0;
        SmallCook = 0;
        BigTimer = 0;
        SmallTimer = 0;
        BigStart = false;

        locations[0].Set(6f, 3f, 0f);
        locations[1].Set(6f, -3f, 0f);
        locations[2].Set(2f, 3f, 0f);
        locations[3].Set(2f, 0f, 0f);
        locations[4].Set(2f, -3f, 0f);

        this.transform.position = locations[3];
    }


    // Update is called once per frame, depends on framerate
    //FixedUpdate is independant of framerate
    void FixedUpdate()
    {
        movePlayer();
        interactPlayer();
    }

    /* Movement function, feels somewhat floaty because Input.GetAxis is a float between -1 and 1, so he has to speed up.
     * Doing (int)Input.GetAxis("Horizontal") would cast it to an int, but then there's a delay between all movements while the float gets high enough to be cast to 1
     *  Maybe doing a big if(Input.GetKey(KeyCode.(all the movement keys)) with setting the velocity in every if block would be less floaty, but that would slow things down as it would have to check all 8 keys every frame?
     */
    private void movePlayer()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (this.transform.position.y <= 0)
            {
                temp.Set(this.transform.position.x, this.transform.position.y + 3, 0);
                this.transform.position = temp;
                scale.Set(this.transform.localScale.x - .15f, this.transform.localScale.y - .15f, this.transform.localScale.z - .15f);
                this.transform.localScale = scale;
            }
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (this.transform.position.y >= 0)
            {
                temp.Set(this.transform.position.x, this.transform.position.y - 3, 0);
                this.transform.position = temp;
                scale.Set(this.transform.localScale.x + .15f, this.transform.localScale.y + .15f, this.transform.localScale.z + .15f);
                this.transform.localScale = scale;
            }
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (this.transform.position.x >= 4)
            {
                temp.Set(this.transform.position.x - 2, this.transform.position.y, 0);
                this.transform.position = temp;
                sprite.flipX = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (this.transform.position.x <= 4)
            {
                temp.Set(this.transform.position.x + 2, this.transform.position.y, 0);
                this.transform.position = temp;
                sprite.flipX = true;
            }
        }

        



    }

    private void interactPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (this.transform.position == locations[0])
            {
                if (!smallOven.baking)
                {
                    smallOven.bakeCommand();
                }
                if (smallOven.done)
                {
                    gameManager.smallCookies += 3;
                }
                if (bigOven.burned)
                {
                    bigOven.resetVars();
                }
            }

            if (this.transform.position == locations[1])
            {
                if (!bigOven.baking)
                {
                    bigOven.bakeCommand();
                }
                if (bigOven.done)
                {
                    //if it's done, restock;
                }
                if (bigOven.burned)
                {
                    bigOven.resetVars();
                }

            }


            //serve cookies!


        }
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
