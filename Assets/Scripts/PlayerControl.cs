using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Vector2 movement;
    // private Animator anim;
    public int movespeed = 0;
    private Vector2 speed;
    // public GameManager gameManager;
   // private Animator anim;
    private float velx;
    private float vely;

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
        speed.Set(movespeed, movespeed);
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
        movePlayer();
    }

    /* Movement function, feels somewhat floaty because Input.GetAxis is a float between -1 and 1, so he has to speed up.
     * Doing (int)Input.GetAxis("Horizontal") would cast it to an int, but then there's a delay between all movements while the float gets high enough to be cast to 1
     *  Maybe doing a big if(Input.GetKey(KeyCode.(all the movement keys)) with setting the velocity in every if block would be less floaty, but that would slow things down as it would have to check all 8 keys every frame?
     */
    private void movePlayer()
    {
        //get input axes
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        print("x: " + inputX + "y: " + inputY);
        // move player according to the axes
        movement = new Vector2(speed.x * inputX, speed.y * inputY);
        rb2D.velocity = movement;
    }

    private void OnTriggerEnter2D(Collider2D collision) { 
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
