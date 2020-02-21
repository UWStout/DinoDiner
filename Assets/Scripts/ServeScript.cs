using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServeScript : MonoBehaviour
{
    public Rigidbody2D Bigbox;
    public Rigidbody2D Smallbox;
    Vector2 temp;


    // Start is called before the first frame update
    void Start()
    {
        temp = new Vector2(-1.0f, 0.0f);
        /* To Do:
         * Link the different kinds of cookie(boxes) to this, and spawn/serve them on the same x-axis as this object.
         * 
         */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
/*
    void ThrowCook()
    {
        //if E is pressed then it throws a small cookie then reduces inventory of cookie
        if (Input.GetKeyDown(KeyCode.E) && SmallCook != 0)
        {
            Rigidbody2D clone;
            clone = Instantiate(Small, transform.position, transform.rotation);
            clone.AddForce(temp);
            SmallCook--;

        }
        //if Q is pressed, player throws a big cookie and reduces big cookie count
        if (Input.GetKeyDown(KeyCode.Q) && BigCook != 0)
        {
            Rigidbody2D clone2;
            clone2 = Instantiate(Small, transform.position, transform.rotation);
            clone2.AddForce(temp);
            BigCook--;
        }
    }
    */
}
