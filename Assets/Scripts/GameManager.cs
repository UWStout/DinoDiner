<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
=======
﻿using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //static allows this to be accessed by anything else in the scene;
    public static GameManager instance = null;

    public int score = 0;
    public Text scorecountText;

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

        //set this to not be destroyed when going between scenes
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        scorecountText = GameObject.Find("ScoreCountText").GetComponent<Text>();
        setScoreCountText();
>>>>>>> 7acb2746e2bc44ee28800ac67090ef9055389569
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        
    }
=======
    }

    public void setScoreCountText()
    {
        scorecountText.text = "Score: " + score.ToString();
    }

>>>>>>> 7acb2746e2bc44ee28800ac67090ef9055389569
}