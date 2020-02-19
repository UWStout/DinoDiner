using UnityEngine;

public class OvenScript : MonoBehaviour
{
    public float bakeSpeed = 0;
    public float timeLeft = 0;
    public GameObject cookieType;
    public int numCookies = 0;
    public bool baking = false;
    public bool done = false;
    public bool burning = false;
    public bool burned = false;
    public GameObject linkedHandle;

    // Start is called before the first frame update
    void Start()
    {
        /* To Do:
         * Make a bakeCookie() function that, after bakeSpeed seconds, give the player numCookies cookieTypes
         */
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (baking)
        {
            linkedHandle.SetActive(true);
            print("timeleft= "+ timeLeft + " done=" + done + " baking=" + baking + " burned=" + burned);

            timeLeft -= Time.deltaTime;

            if (timeLeft <= 0 )
            {
                done = true;
                burning = true;
            }
            if (timeLeft < -bakeSpeed)
            {
                done = false;
                burned = true;
            }
        }
    }

    public void bakeCommand()
    {
        timeLeft = bakeSpeed;
        baking = true;
    }

    public void resetVars()
    {
        baking = false;
        done = false;
        burning = false;
        burned = false;
        timeLeft = 0;
        linkedHandle.SetActive(false);

    }
}
