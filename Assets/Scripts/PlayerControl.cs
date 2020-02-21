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
    public Rigidbody2D Bigbox;
    public Rigidbody2D Smallbox;
    Vector2 CookieSpeed;

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
        CookieSpeed = new Vector2(-1.0f, 0.0f);

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

    private void movePlayer()
    {
        //this function gets input either from wasd or the arrow keys. all the if statements do the same thing except change where the player moves and the size it is
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (this.transform.position.y <= 0)
            {
                //these two lines are to change the position of the player character 
                temp.Set(this.transform.position.x, this.transform.position.y + 3, 0);
                this.transform.position = temp;
                //this changes the size of the player model to give the play area depth
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
        //this function is for baking and serving
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //if the player is in front of the small oven they can interact with it
            if (this.transform.position == locations[0])
            {
                if (!smallOven.baking)
                {
                    smallOven.bakeCommand();
                }
                if (smallOven.done)
                {
                    gameManager.smallCookies += 3;
                    smallOven.resetVars();
                }
                if (smallOven.burned)
                {
                    smallOven.resetVars();
                }
            }

            else if (this.transform.position == locations[1])
            {
                if (!bigOven.baking)
                {
                    bigOven.bakeCommand();
                }
                if (bigOven.done)
                {
                    gameManager.bigCookies += 1;
                    bigOven.resetVars();
                }
                if (bigOven.burned)
                {
                    bigOven.resetVars();
                }

            }

            else if (this.transform.position == locations[2] || this.transform.position == locations[3] || this.transform.position == locations[4])
            {
                if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.C) && SmallCook != 0)
                {
                    Rigidbody2D clone;
                    clone = Instantiate(Smallbox, transform.position, transform.rotation);
                    clone.AddForce(temp);
                    SmallCook--;

                }
                //if Q is pressed, player throws a big cookie and reduces big cookie count
                if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.V) && BigCook != 0)
                {
                    Rigidbody2D clone2;
                    clone2 = Instantiate(Bigbox, transform.position, transform.rotation);
                    clone2.AddForce(temp);
                    BigCook--;
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

    }


}
