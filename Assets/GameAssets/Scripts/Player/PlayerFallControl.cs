using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerFallControl : MonoBehaviour
{
    //class
    private CameraShake cameraShake;
    private PlayerMovement playerMovement;
    private GameManager _gameManager;

    //animator
    [SerializeField] private Animator CharacterAnimator;

    [SerializeField] private GameObject character;
    private static int hasAnimationPlayed = 0;
    //private bool hasFinish = false;

    [SerializeField] private float fallThreshold = -8f;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        
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
        }
        
    }
}
