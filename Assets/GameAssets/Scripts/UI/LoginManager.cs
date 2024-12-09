using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoginManager : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_InputField userNameInput;
    [SerializeField] private Button playButton;

    public static string UserName { get; private set; }

    private void Start()
    {
        playButton.onClick.AddListener(StartGame);
    }

    private void StartGame()
    {
        if (!string.IsNullOrEmpty(userNameInput.text))
        {
            UserName = userNameInput.text;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            Debug.Log("Username is empty");
        }
    }
}
