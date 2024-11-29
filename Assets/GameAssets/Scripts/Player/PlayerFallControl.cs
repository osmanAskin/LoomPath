using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerFallControl : MonoBehaviour
{ 
    private float fallThreshold = -8f;
    
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }
    
    private void Update()
    {
        if (transform.position.y < fallThreshold)
        {
            _gameManager.RespawnPlayer();
        }
    }
}
