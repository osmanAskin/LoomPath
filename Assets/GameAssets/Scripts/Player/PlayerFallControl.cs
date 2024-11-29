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

    //konuskan karakterin sahneye gelmesi icin
    private bool hasDeadOnce = false;

    //animator
    [SerializeField] private Animator CharacterAnimator;

    [SerializeField] private GameObject character;
    private bool hasAnimationPlayed = false;
    private int characterCounter = 0;

    private float fallThreshold = -8f;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (transform.position.y < fallThreshold)
        {

            StartCoroutine(Camera.main.GetComponent<CameraShake>().Shake(0.1f, 0.1f));
            _gameManager.RespawnPlayer();
            hasDeadOnce = true;
        }

        if (hasDeadOnce)
        {
            if (!hasAnimationPlayed)
            {
                CharacterAnimator.SetBool("Character", true);
                hasAnimationPlayed = true;
                characterCounter++;
            }

            if (hasAnimationPlayed)
            {
                CharacterAnimator.SetBool("Finish", true);
                
                Debug.Log(hasDeadOnce);
            }

            if (characterCounter == 0)
            {
                DontDestroyOnLoad(character);
                Debug.Log(characterCounter);
            }
        }
    }
}
