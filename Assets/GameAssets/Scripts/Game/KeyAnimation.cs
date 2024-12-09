using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyAnimation : MonoBehaviour
{
    [SerializeField] private float movementRange = 3f;
    [SerializeField] private float speed = 2f; 

    [SerializeField] private float startYPosition;

    private void Start()
    {
        startYPosition = transform.position.y;
    }

    private void Update()
    {
        float newY = startYPosition + Mathf.PingPong(Time.time * speed, movementRange * 2) - movementRange;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

}
