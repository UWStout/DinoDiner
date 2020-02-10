using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieScript : MonoBehaviour
{
    public int speed = 5;


    // Start is called before the first frame update
    void Start()
    {
        //this.velocity;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x + 2, this.transform.position.y, this.transform.position.z);

    }
}
