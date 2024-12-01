using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Tilemaps;

public class TrapController : MonoBehaviour
{
    //[SerializeField] private Tilemap tilemapPiece;
    [SerializeField] private GameObject trap;
    
    [SerializeField] private float moveAmountX;
    [SerializeField] private float moveAmountY;
    //[SerializeField] private float moveAmountZ;
    [SerializeField] private float duration;

    private bool isTrigger = false;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (isTrigger != true)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                isTrigger = true;
                //trap.transform.DOMove(new Vector3(moveAmountX,moveAmountY,moveAmountZ), duration);
                trap.transform.DOMove(new Vector2(moveAmountX , moveAmountY), duration);
            }

        }
    }
}
