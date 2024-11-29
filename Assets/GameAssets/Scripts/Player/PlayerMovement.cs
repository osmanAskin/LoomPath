using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private bool isFacingRight = true;

    [SerializeField] private Animator animator;
    
    private GameManager _gameManager;
    [SerializeField] private DialogueManage _dialogueManager; 

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer; 
    private float speed = 8f; 
    private float jumpForce = 20f;
    
    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _dialogueManager = FindObjectOfType<DialogueManage>();
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        
        //animator.SetFloat("Speed", Mathf.Abs(horizontal));
        
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); //TODO;
        }

        if (Input.GetButtonDown("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        
        if (isGrounded() != true)
        {
            //animator.SetTrigger("JumpTrigger");
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool isGrounded()
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
            _gameManager.NextLevel();
        }

        if (col.CompareTag("Trap"))
        {
            rb.bodyType = RigidbodyType2D.Static;    
            animator.SetBool("IsDead" , true);
            _gameManager.RespawnPlayer();
        }
/*
        if (col.CompareTag("DialogueCharacter"))
        {
            if (_dialogueManager != null)
            {
                _dialogueManager.StartDialogue();
            }
        }
    }

    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("DialogueCharacter"))
        {
            _dialogueManager.StopDialogue();
            StartCoroutine(_dialogueManager.WaitForDialogue());
        }
        
    }
    */
}
    }

