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
            //activates baking and counts down the time, and if time runs out a second time the cookies become burnt.
            linkedHandle.SetActive(true);
            print("timeleft= "+ timeLeft + " done=" + done + " baking=" + baking + " burned=" + burned);
            //counts down the time
            timeLeft -= Time.deltaTime;
            //this if statement is what determines the first countdown for the cookies to be cooked.
            if (timeLeft <= 0 )
            {
                done = true;
                burning = true;
            }
            //this statement determines if the cookies become burnt
            if (timeLeft < -bakeSpeed)
            {
                done = false;
                burned = true;
            }
        }
    }

    public void bakeCommand()
    {
        //this can be called elsewhere to start the baking.
        timeLeft = bakeSpeed;
        baking = true;
    }

    public void resetVars()
    {
        //resets the variables so that the baking can be done again
        baking = false;
        done = false;
        burning = false;
        burned = false;
        timeLeft = 0;
        linkedHandle.SetActive(false);

    }
}
