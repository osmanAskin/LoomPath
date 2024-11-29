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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            TogglePausedMenu();
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

     if (IsPaused) { Time.timeScale = 0;}
     else { Time.timeScale = 1;}
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
    
    
}
