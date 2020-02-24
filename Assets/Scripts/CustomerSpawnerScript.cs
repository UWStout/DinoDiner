using System.Collections;
using UnityEngine;

public class CustomerSpawnerScript : MonoBehaviour
{
    public GameObject[] pool;
    public float scale;
    public int renderOrder = 0;
    public GameManager gameManager;
    bool crRunning = false;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnCustomer());
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (!crRunning && !gameManager.isPaused)
        {
            print("Starting CR");
            StartCoroutine(spawnCustomer());
        }
    }

    private IEnumerator spawnCustomer()
    {
        crRunning = true;
        print("true");
        while (!gameManager.isPaused)
        {
            yield return new WaitForSeconds(Random.Range(0, 16));
            if (!gameManager.isPaused)
            {
                GameObject clone = Instantiate(pool[Random.Range(0, 3)], this.transform.position, this.transform.rotation);
                clone.transform.localScale = new Vector3(scale, scale, 1);
                SpriteRenderer sClone = clone.GetComponent<SpriteRenderer>();
                sClone.sortingOrder = renderOrder;
            }
        }
        crRunning = false;
        print("false");
    }
}
