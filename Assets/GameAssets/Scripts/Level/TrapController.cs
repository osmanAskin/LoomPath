using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Tilemaps;

public class TrapController : MonoBehaviour
{
    
    //class
    AudioManager audioManager;
    
    [SerializeField] private GameObject trap;
    
    [SerializeField] private float moveAmountX;
    [SerializeField] private float moveAmountY;
    [SerializeField] private float duration;

    private bool isTrigger = false;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (isTrigger != true)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                //belki sonra sequance olusturulabilir
                isTrigger = true;
                trap.transform.DOMove(new Vector2(moveAmountX , moveAmountY), duration);
                
                //audio
                audioManager.Play(SoundType.PlatfomTrigger);
                
            }

        }
    }
}
