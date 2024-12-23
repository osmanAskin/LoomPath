using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Searcher;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerFallControl : MonoBehaviour
{
    //class
    private CameraShake cameraShake;
    private PlayerMovement playerMovement;
    private GameManager _gameManager;
    private AudioManager _audioManager;
    
    //animator
    [SerializeField] private Animator CharacterAnimator;

    [SerializeField] private GameObject character;
    private static int hasAnimationPlayed = 0;
    //private bool hasFinish = false;

    [SerializeField] private float fallThreshold = -8f;

    //flag
    private bool hasPlayerDeadSound = false;
    
    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _audioManager = FindObjectOfType<AudioManager>();
        
            if (hasAnimationPlayed >= 1)
            {
                CharacterAnimator.SetBool("CharacterCome", true);
            }
            
            Debug.Log("start  " +  hasAnimationPlayed);
    }

    private void Update()
    {
        if (transform.position.y < fallThreshold)
        {
            StartCoroutine(Camera.main.GetComponent<CameraShake>().Shake(0.1f, 0.1f));
            
            _gameManager.RespawnPlayer();
            hasAnimationPlayed++;

            if (!hasPlayerDeadSound)
            {
                //audio
                _audioManager.Play(SoundType.PlayerDead);
                hasPlayerDeadSound = true;

            }
            
        }
        
    }
}
