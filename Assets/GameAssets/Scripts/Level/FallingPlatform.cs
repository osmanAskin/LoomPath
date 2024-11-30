using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private float fallDelay = .2f;
         private float destroyDelay = .7f;
    
        [SerializeField] private Rigidbody2D rb;
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                StartCoroutine(Fall());
            }
        }
    
        private IEnumerator Fall()
        {
            yield return new WaitForSeconds(fallDelay);
            rb.bodyType = RigidbodyType2D.Dynamic;
            Destroy(gameObject , destroyDelay);
    
        }
}
