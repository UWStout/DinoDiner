using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMovementScript: MonoBehaviour
{
    private Vector3 origin;
    private Vector3 destination;
    public int timetoendsec = 5;


    // Start is called before the first frame update
    void Start()
    {
        //origin = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        InvokeRepeating("moveForward", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void moveForward()
    {
        this.transform.position = new Vector3(this.transform.position.x + 2, this.transform.position.y, this.transform.position.z);
    }





}
