using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject resumeButton;
    [SerializeField] private GameObject quitButton;
    private bool isPaused = false;
    
    
    public void pauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
        resumeButton.SetActive(true);
        quitButton.SetActive(true);
    }
    
    public void resumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        resumeButton.SetActive(false);
        quitButton.SetActive(false);
    }

    public void quitGame()
    {
        Debug.Log("Quit");
        SceneManager.LoadScene("Scenes/Menu");
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
                pauseGame();
            else
                resumeGame();
        }
    }
}
