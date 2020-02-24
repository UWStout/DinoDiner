using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsScript : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject controlsPanel;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    public void PauseButton()
    {
        if (!gameManager.isPaused) {
            
            Time.timeScale = 0;
            pausePanel.SetActive(true);
            gameManager.isPaused = true;
        }
        else
        {
            
            pausePanel.SetActive(false);
            Time.timeScale = 1;
            gameManager.isPaused = false;
        }
    }

    public void ResumeButton()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        gameManager.isPaused = false;
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void BackButton()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void OpenControlsButton()
    {
        controlsPanel.SetActive(true);
    }

    public void CloseControlsButton()
    {
        controlsPanel.SetActive(false);
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("diner");
    }

}
