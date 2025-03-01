using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    //coyote time
     private float coyoteTime = 0.1f;
     private float coyoteTimeCounter;
    
    //buffer
    [SerializeField] private float jumpBufferTime = 0.2f;
    [SerializeField] private float jumpBufferCounter;
    
    private float horizontal;
    private bool isFacingRight = true;

    [SerializeField] private Animator animator;
    
    //classes referance
    private GameManager _gameManager;
    [SerializeField] private DialogueManage _dialogueManager; 
    private AudioManager _audioManager;
    private PlayerExplosion _playerExplosion;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer; 
    private float speed = 10f; 
    private float jumpForce = 20f;
    
    //door referance
    [SerializeField] private Transform doorPosition;
    
    //player referance
    [SerializeField] private SpriteRenderer playerGFX;
    
    private void Start()
    {
        _audioManager = FindObjectOfType<AudioManager>();
        _gameManager = FindObjectOfType<GameManager>();
        _dialogueManager = FindObjectOfType<DialogueManage>();
        _playerExplosion = FindObjectOfType<PlayerExplosion>();
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (isGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferTime;
        }

        else
        {
            jumpBufferCounter -= Time.deltaTime;    
        }
        
        if (coyoteTimeCounter > 0f && jumpBufferCounter > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            jumpBufferCounter = 0f;
            
            //audio
            _audioManager.Play(SoundType.PlayerJump);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            
            coyoteTimeCounter = 0f;
        }

        Flip();
    }
    

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    public bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)//TODO: bunuda aynı sekilde yap
    {
        if (col.gameObject.CompareTag("Key"))
        {
            _gameManager.PlayerTouchedKey();
            Destroy(col.gameObject);
            
            //audio
            _audioManager.Play(SoundType.Key);
        }

        if (col.gameObject.CompareTag("Door"))
        {
            if (_gameManager.hasPlayerKey)
            {
                gameObject.transform.position = doorPosition.transform.position; 
                rb.bodyType = RigidbodyType2D.Static;
                _gameManager.NextLevel();   
                
                //audio
                _audioManager.Play(SoundType.Door);
            }
        }

        if (col.CompareTag("Trap"))
        {
            StartCoroutine(Camera.main.GetComponent<CameraShake>().Shake(0.1f, 0.1f));
            rb.bodyType = RigidbodyType2D.Static;
           //dead
           //playerGFX.enabled = false;
           //_playerExplosion.PlayerDeadExplode();
           transform.DOScale(0.0f, 0.2f);
            
            _gameManager.RespawnPlayer();
            
            //audio
            _audioManager.Play(SoundType.PlayerDead);
        }
        
        if(col.CompareTag("Water"))
        {
            //audio
            _audioManager.Play(SoundType.WaterTrigger);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DialogueCharacter"))
        {
            _dialogueManager.EndDialogue();    
        }
        
        if(other.CompareTag("Water"))
        {
            //audio
            _audioManager.Play(SoundType.WaterTrigger);
        }
        
           
    }
    
}