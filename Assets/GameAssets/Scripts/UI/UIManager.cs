using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    public bool IsPaused = false;

    //[SerializeField] private Rigidbody2D playerRb;

    //[SerializeField] private Animator fadeAnimator;
    
        //class
        DialogueManage dialogueManager;
        
        private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePausedMenu();
        }
    }

    private void TogglePausedMenu()
    {
            IsPaused = !IsPaused;
            pauseMenu.SetActive(IsPaused);

            if (IsPaused)
            {
                //playerRb.bodyType = RigidbodyType2D.Static;
                //Time.timeScale = 0f;
            }

            
            if (!IsPaused)
            {
                //Time.timeScale = 1f;
            }

    }

    public void StartButton()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);

        /*
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        */    
    
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ResumeButton()
    {
        
    }
    
    public void OpenGoogleAccountWebsite(string url)
    {
        Application.OpenURL(url);
    }

    public void OpenTwitterAccount(string url)
    {
        Application.OpenURL(url);
    }

    public void OpenLinkedinAccount(string url)
    {
        Application.OpenURL(url);
    }
    

}
