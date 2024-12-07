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
    [SerializeField] private float coyoteTime = 0.2f;
    [SerializeField] private float coyoteTimeCounter;
    
    private float horizontal;
    private bool isFacingRight = true;

    [SerializeField] private Animator animator;
    
    private GameManager _gameManager;
    [SerializeField] private DialogueManage _dialogueManager; 

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer; 
    private float speed = 10f; 
    private float jumpForce = 40f;
    
    //door referance
    [SerializeField] private Transform doorPosition;
    
    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _dialogueManager = FindObjectOfType<DialogueManage>();
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

        if (Input.GetButtonDown("Jump") && coyoteTimeCounter > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            coyoteTimeCounter = 0f;
        }

        if (Input.GetButtonDown("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
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
        }

        if (col.gameObject.CompareTag("Door"))
        {
            if (_gameManager.hasPlayerKey)
            {
                gameObject.transform.position = doorPosition.transform.position; 
                rb.bodyType = RigidbodyType2D.Static;
                _gameManager.NextLevel();   
            }
        }

        if (col.CompareTag("Trap"))
        {
            rb.bodyType = RigidbodyType2D.Static;
            transform.DOScale(0.0f, 0.2f);
            
            _gameManager.RespawnPlayer();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DialogueCharacter"))
        {
            _dialogueManager.EndDialogue();    
        }

           
    }
    
}

