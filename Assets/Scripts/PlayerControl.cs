using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Vector2 movement;
    // private Animator anim;
    public int movespeed = 0;
    private Vector2 speed;
    // public GameManager gameManager;

    // Use this for initialization
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        speed.Set(movespeed, movespeed);
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
    }

    /** Movement function, feels somewhat floaty
     *  No parameters
     **/
    private void movePlayer()
    {
        //get input axes
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        // move player according to the axes
        movement = new Vector2(speed.x * inputX, speed.y * inputY);
        rb2D.velocity = movement;
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
