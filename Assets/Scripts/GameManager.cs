using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    //static allows this to be accessed by anything else in the scene;
    public static GameManager instance = null;

    public int score = 0;
    public Text scorecountText;
    public Text sCookieCountText;
    public Text bCookieCountText;
    public int smallCookies = 0;
    public int bigCookies = 0;
    public bool isPaused = false;


    

    //awake is called before start
    private void Awake()
    {
        //check if instance already exists
        if (instance == null)
        {
            //if not, set it to this one we've created
            instance = this;
        }
        else if (instance != this)
        {
            //if a gamemanager already exists, destroy this one we'vev created
            //this enforces the singleton pattern, meaning there can only be one instnace of the GameManager
            Destroy(this.gameObject);
        }
        /*
        //set this to not be destroyed when going between scenes
        DontDestroyOnLoad(this.gameObject);

        Not needed, since the game is only 1 level - it's small enough to not need to save anything.
        */
    }

    // Start is called before the first frame update
    void Start()
    {
        setText();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = 1;
    }

    public void setText()
    {
        //sets the scores and cookies into the game space
        scorecountText.text = "Score: " + score.ToString();
        sCookieCountText.text = smallCookies.ToString();
        bCookieCountText.text = bigCookies.ToString();

    }
    public void GameOver()
    {

        SceneManager.LoadScene("TitleScene");
    }
   
    
}
