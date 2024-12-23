using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerExplosion : MonoBehaviour
{
    private Collider2D[] inExplosionRadius = null;
    [SerializeField] private float ExplosionForceMulti = 5f;
    [SerializeField] private float ExplosionRadius = 5f;
    
    [SerializeField] private List<GameObject> explodePiece;
    

    public void Explode()
    {
        inExplosionRadius = Physics2D.OverlapCircleAll(transform.position, ExplosionRadius);

        foreach (Collider2D o in inExplosionRadius)
        {
            Rigidbody2D o_rigidbody = o.GetComponent<Rigidbody2D>();
            if (o_rigidbody != null)
            {
                Vector2 distanceVector = o.transform.position - transform.position;
                if (distanceVector.magnitude > 0) // NaN hatasını önlemek için
                {
                    float explosionForce = ExplosionForceMulti / distanceVector.magnitude;
                    o_rigidbody.AddForce(distanceVector.normalized * explosionForce);
                }
            }
        }
    }

    public void PlayerDeadExplode()
    {
        foreach (GameObject piece in explodePiece)
        {
            piece.SetActive(true);
            
            Rigidbody2D rb = piece.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 randomDirection = Random.insideUnitCircle.normalized;
                rb.AddForce(randomDirection * ExplosionForceMulti, ForceMode2D.Impulse);
            }
        }

        Explode();
    }

    private void OnDrawGizmos() // Patlama yarıçapını çiz
    {
        Gizmos.DrawWireSphere(transform.position, ExplosionRadius);
    }
}