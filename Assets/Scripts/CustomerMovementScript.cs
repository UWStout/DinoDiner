using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMovementScript: MonoBehaviour
{
    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        //origin = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        InvokeRepeating("moveForward", 1f, speed/5);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void moveForward()
    {
        this.transform.position = new Vector3(this.transform.position.x + 1, this.transform.position.y, this.transform.position.z);
    }





}
