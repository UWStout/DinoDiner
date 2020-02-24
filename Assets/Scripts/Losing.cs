using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Losing : MonoBehaviour
{
    // Start is called before the first frame update

    public GameManager gameManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Customer")
        {
           
            gameManager.GameOver();

        }

    }
}
