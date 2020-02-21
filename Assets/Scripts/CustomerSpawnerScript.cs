using System.Collections;
using UnityEngine;

public class CustomerSpawnerScript : MonoBehaviour
{
    public GameObject[] pool;
    public float scale;
    int wait_time;


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

        while (true)
        {
            wait_time = Random.Range(0, 20);
            yield return new WaitForSeconds(wait_time);
            GameObject clone = new GameObject();
            clone = Instantiate(pool[Random.Range(0, 3)], this.transform.position, this.transform.rotation);
            clone.transform.localScale = new Vector3(scale, scale, 1);
        }
    }
}
