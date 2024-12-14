using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class UIManager : MonoBehaviour
{
    //audio
    [SerializeField] private AudioMixer audioMixer;
    private bool isMuted = false;
    
    [SerializeField] private GameObject pauseMenu;
    public bool IsPaused = false;
    
        //class
        DialogueManage dialogueManager;
        
        private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePausedMenu();
        }
    }

        
    public void ToggleMute()//audio
    {
        isMuted = !isMuted;
        if (isMuted)
        {
            audioMixer.SetFloat("MusicVolume", -80f);
        }
        else
        {
            audioMixer.SetFloat("MusicVolume", 0f);
        }
    }
        
    private void TogglePausedMenu()
    {
            IsPaused = !IsPaused;
            pauseMenu.SetActive(IsPaused);

            if (IsPaused)
            {
                Time.timeScale = 0f;
            }

            
            else
            {
                Time.timeScale = 1f;
            }
    }

    private void OnEnable()
    {
        Time.timeScale = 1f;
    }

    public void StartButton()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
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
        OnEnable();
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
