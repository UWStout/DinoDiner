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
    public GameObject bigBox;
    public GameObject smallBox;
    public Rigidbody2D Bigbox;
    public Rigidbody2D Smallbox;
    Vector2 CookieSpeed;


    private int pos;

    public OvenScript bigOven;
    public OvenScript smallOven;

    public Vector3[] rowLocs = new Vector3[3];
    public Vector3[] ovenLocs = new Vector3[3];
    private Vector3 scale = new Vector3();
    private Vector3 cookieScale = new Vector3();
    private Vector3 cookiePos = new Vector3();

    private bool inRows = true;

    // Use this for initialization
    void Start()
    {
        // if the GameManager is unbound in the editor, the below will bind it
        // gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();


        rb2D = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        pos = 1;

        rowLocs[0].Set(5f, 6f, 0f);// row 1
        rowLocs[1].Set(5f, 1f, 0f);// row 2
        rowLocs[2].Set(5f, -6f, 0f);// row 3

        ovenLocs[0].Set(14f, 3f, 0f);// small oven
        ovenLocs[1].Set(15f, -2f, 0f);// between them
        ovenLocs[2].Set(16f, -6f, 0f);// big oven

        this.transform.position = rowLocs[pos];



        CookieSpeed = new Vector2(-50.0f, 0.0f);
        pos = 3;


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
            if (inRows)
            {
                if(pos > 0)
                {
                    --pos;
                    rb2D.position = rowLocs[pos];
                    scale.Set(this.transform.localScale.x - .25f, this.transform.localScale.y - .25f, 1);
                    this.transform.localScale = scale;
                }
            }
            else
            {
                if (pos > 0)
                {
                    --pos;
                    rb2D.position = ovenLocs[pos];
                    scale.Set(this.transform.localScale.x - .25f, this.transform.localScale.y - .25f, 1);
                    this.transform.localScale = scale;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (inRows)
            {
                if (pos < 2)
                {
                    ++pos;
                    rb2D.position = rowLocs[pos];
                    scale.Set(this.transform.localScale.x + .25f, this.transform.localScale.y + .25f, 1);
                    this.transform.localScale = scale;
                }
            }
            else
            {
                if (pos < 2)
                {
                    ++pos;
                    rb2D.position = ovenLocs[pos];
                    scale.Set(this.transform.localScale.x + .25f, this.transform.localScale.y + .25f, 1);
                    this.transform.localScale = scale;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (!inRows)
            {
                rb2D.position = rowLocs[pos];
                sprite.flipX = false;
                inRows = true;
            }

        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (inRows)
            {
                rb2D.position = ovenLocs[pos];
                sprite.flipX = true;
                inRows = false;
                
            }
        }
    }

    private void interactPlayer()
    {
        //this function is for baking and serving
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //if the player is in front of the small oven they can interact with it
            if (this.transform.position == ovenLocs[0])
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

            else if (this.transform.position == ovenLocs[2])
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
        if (inRows)

        if (this.transform.position == rowLocs[2] || this.transform.position == rowLocs[0] || this.transform.position == rowLocs[4])
         {
            //this throws the small cookie when E or V are pressed
            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.V))
            {
                if (gameManager.smallCookies > 0)
                {
                    GameObject clone = new GameObject();
                    clone = Instantiate(smallBox, this.transform.position, this.transform.rotation);
                    cookieScale.Set(this.transform.localScale.x - .5f, this.transform.localScale.y - .5f, 1);
                    clone.transform.localScale = cookieScale;
                    --gameManager.smallCookies;
                    Rigidbody2D cloned;
                    //clones a small cookie box, and sends it to the left at a certain speed
                    cloned = Instantiate(Smallbox, transform.position, transform.rotation);
                    cloned.AddForce(CookieSpeed);
                    gameManager.smallCookies--;

                }
            }
            //if Q is pressed, player throws a big cookie and reduces big cookie count
            if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.C))
            {
                if (gameManager.bigCookies > 0)
                {
                    GameObject clone = Instantiate(bigBox, this.transform.position, this.transform.rotation);
                    cookieScale.Set(this.transform.localScale.x - .5f, this.transform.localScale.y - .5f, 1);
                    clone.transform.localScale = cookieScale;
                    --gameManager.bigCookies;
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
