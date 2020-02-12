using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieScript : MonoBehaviour
{
    public GameManager gameManager;
    public int speed = 5;
    public Rigidbody2D rb2d;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb2d = this.GetComponent<Rigidbody2D>();
        rb2d.AddForce(new Vector2(-speed*100, 0));
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Customer")
        {
            collision.gameObject.SetActive(false);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            gameManager.score++;
            gameManager.setScoreCountText();
            
        }
    }
}
