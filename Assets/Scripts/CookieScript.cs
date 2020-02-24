using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieScript : MonoBehaviour
{
    public GameManager gameManager;
    public int speed;
    public Rigidbody2D rb2d;
    public bool isSmall;
    public AudioClip clip;
    AudioSource crunch;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb2d = this.GetComponent<Rigidbody2D>();
        rb2d.AddForce(new Vector2(-speed * 100, 0));
        crunch = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    //  TODO if cookie is big cookie, push customer back a lot and delete customer. If cookie is small cookie, push back a little
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Customer")
        {

            AudioSource.PlayClipAtPoint(clip, new Vector3(0,0,-100));
            Destroy(collision.gameObject);
            if (isSmall)
            {

                Destroy(this.gameObject);
            }
            gameManager.score++;
            gameManager.setText();

        }
        if (collision.gameObject.tag == "CookieStopper")
        {
            Destroy(this.gameObject);
        }
    }

        

}
