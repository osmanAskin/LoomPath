using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelLoader : MonoBehaviour
{
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            _gameManager.NextLevel();                        
        }
    }
}
    
    
