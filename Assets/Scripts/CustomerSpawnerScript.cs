using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawnerScript : MonoBehaviour
{
    private int spawnrate;
    public GameObject[] pool;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnCustomer());
    }
       

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnCustomer()
    {
        int wait_time;
        while (true)
        {
            wait_time = Random.Range(0, 10);
            yield return new WaitForSeconds(wait_time);
            Instantiate(pool[Random.Range(0, 3)], this.transform.position, this.transform.rotation);
        }
    }
}
