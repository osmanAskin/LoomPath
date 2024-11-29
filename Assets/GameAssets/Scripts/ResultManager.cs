using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text resultText;

    private void Start()
    {
        string userName = LoginManager.UserName;
        float elapsedTime = GameScoreTimer.ElapsedTime;
        
        resultText.text = $"{userName}, oyunu {elapsedTime:F2} saniyede tamamladınız!";
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(0);
        Debug.Log("RestartButton clicked");
    }
}
