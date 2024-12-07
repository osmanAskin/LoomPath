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
    
    //[SerializeField] private Animator fadeAnimator;
    
        //class
        DialogueManage dialogueManager;
        
        private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            TogglePausedMenu();
            //dialogueManager.EndDialogue(); //triggerdayken ayni zamanda end dialog olmuyor birine oncelik ver
            /*
            if (IsPaused)
            {
                
                Cursor.lockState = CursorLockMode.None; // Fareyi serbest bırak
                Cursor.visible = true;    
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            */
        }
    }

    private void TogglePausedMenu()
    {
     IsPaused = !IsPaused;
     pauseMenu.SetActive(IsPaused);

     /*
     if (IsPaused) { Time.timeScale = 0;}
     else { Time.timeScale = 1;}
    */
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
