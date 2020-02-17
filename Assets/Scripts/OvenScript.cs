using UnityEngine;

public class OvenScript : MonoBehaviour
{
    public float bakeSpeed = 0;
    public float timeLeft = 0;
    public GameObject cookieType;
    public int numCookies = 0;
    public bool baking = false;
    public bool done = false;
    public bool burned = false;

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
            timeLeft -= Time.deltaTime;
            if ((timeLeft <= 0) || (timeLeft >= -3))
            {
                done = true;
            }
            else if (timeLeft < -3)
            {
                done = false;
                burned = true;
                baking = false;
                timeLeft = 0;
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
        burned = false;
    }
}
