using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelBehaviour : MonoBehaviour
{

    public GameObject ExplosionPrefab;
    public float ExplosionAreaRadius = 5f;
    public float ExplosionDamage = 10f;
    public float FireDamage = 3f;
    public float FireDuration = 5f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Explode();
        }
    }

    void Explode()
    {
        if (ExplosionPrefab != null)
        {   
            GameObject explosion = Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
            ExplosionBehaviour eb = explosion.GetComponent<ExplosionBehaviour>();
            
            if (eb != null)
            {
                eb.lifeTime = FireDuration;
            }
        }

        Collider2D[] victims = Physics2D.OverlapCircleAll(transform.position, ExplosionAreaRadius);
        foreach (Collider2D obj in victims)
        {
            if (obj.CompareTag("Player"))
            {
                Health healthTarget = obj.GetComponent<Health>();
                if (healthTarget != null)
                    healthTarget.TakeDamage((int)ExplosionDamage);
            }
        }

        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, ExplosionAreaRadius);
    }
}
