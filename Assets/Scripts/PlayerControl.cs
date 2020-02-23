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

    private float BigTimer;
    private float SmallTimer;
    private bool BigStart;
    private bool SmallStart;
    private int pos;

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
        BigTimer = 0;
        SmallTimer = 0;
        BigStart = false;
        CookieSpeed = new Vector2(-50.0f, 0.0f);
        pos = 3;

        locations[1].Set(50.94f, -0.18f, 0f);//small oven
        locations[3].Set(52.15f, -6.36f, 0f);//big oven
        locations[0].Set(42.01f, 2.09f, 0f);//row 1
        locations[2].Set(42.01f, -2.13f, 0f);//row 2
        locations[4].Set(42.01f, -8.84f, 0f);//row 3

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
        //this function gets input either from wasd or the arrow keys. Up and down increase/decrease by 2; left and right increase/decrease by 1
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        { 
            pos -= 2;

        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            pos += 2;
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            pos -= 1;
            if (pos == -1)
            {
                pos = 4;
            }
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            pos += 1;
            if (pos == 5)
            {
                pos = 0;
            }
        }
        //these if statements handle the looping if the player hits the bottom of the screen
        if(pos == 5)
        {
            pos = 1;
        }
        if(pos ==6)
        {
            pos = 0;
        }
        if (pos == -1)
        {
            pos = 3;
        }
        if (pos == -2)
        {
            pos = 4;
        }
        //moves the player to a new location
        rb2D.position = locations[pos];
        //these flip the player model if they are on the left or right side
        if (pos == 1 || pos == 3)
        {
            sprite.flipX = true;
        }
        if (pos == 0 || pos == 2 || pos == 4)
        {
            sprite.flipX = false;
        }
    }

    private void interactPlayer()
    {
        //this function is for baking and serving
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //if the player is in front of the small oven they can interact with it
            if (this.transform.position == locations[1])
            {
                if (!smallOven.baking)
                {
                    //starts the baking
                    smallOven.bakeCommand();
                }
                if (smallOven.done)
                {
                    //when the baking is done collect the cookies and reset variables.
                    gameManager.smallCookies += 3;
                    gameManager.setText();
                    smallOven.resetVars();
                }
                if (smallOven.burned)
                {
                    //if the cookies are burned, reset the variables and don't give player any cookies.
                    smallOven.resetVars();
                }
            }

            else if (this.transform.position == locations[3])
            {
                if (!bigOven.baking)
                {//starts baking
                    bigOven.bakeCommand();
                }
                if (bigOven.done)
                {
                    //collects big cookies and resets variables
                    gameManager.bigCookies += 4;
                    gameManager.setText();
                    bigOven.resetVars();
                }
                if (bigOven.burned)
                {
                    //if cookies are burned then reset variables and don't give player cookies.
                    bigOven.resetVars();
                }

            }

        }

        if (this.transform.position == locations[2] || this.transform.position == locations[0] || this.transform.position == locations[4])
         {
            //this throws the small cookie when E or V are pressed
            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.V))
            {
                if (gameManager.smallCookies > 0)
                {
                    Rigidbody2D clone;
                    //clones a small cookie box, and sends it to the left at a certain speed
                    clone = Instantiate(Smallbox, transform.position, transform.rotation);
                    clone.AddForce(CookieSpeed);
                    gameManager.smallCookies--;

                }
            }
            //if Q is pressed, player throws a big cookie and reduces big cookie count
            if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.C))
            {
                if (gameManager.bigCookies > 0)
                {
                    //clones a big cookie box then sends it to the left.
     
                    Rigidbody2D clone2;
                    clone2 = Instantiate(Bigbox, transform.position, transform.rotation);
                    clone2.AddForce(CookieSpeed);
                    gameManager.bigCookies--;
                }
            }
         }
    }
}
