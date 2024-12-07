using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text resultText;
    [SerializeField] private TMPro.TMP_Text usersText;

    private void Start()
    {
        string userName = LoginManager.UserName;
        float elapsedTime = GameScoreTimer.ElapsedTime;
        
        resultText.text = elapsedTime.ToString("F2");
        usersText.text = userName;
    }

    public void BackToTheMainMenuButton()
    {
        SceneManager.LoadScene(0);
        Debug.Log("RestartButton clicked");
    }
}
