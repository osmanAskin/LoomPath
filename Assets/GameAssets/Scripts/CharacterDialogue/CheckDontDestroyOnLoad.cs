using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDontDestroyOnLoad : MonoBehaviour
{
    //class
    private PlayerFallControl _playerFallControl;

    private void Start()
    {
        _playerFallControl = FindObjectOfType<PlayerFallControl>();
    }

    private void Update()
    {
        
    }
}
