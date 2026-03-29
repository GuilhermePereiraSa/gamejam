using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShooterRole : MonoBehaviour
{


    public GameObject ProjectilePrefab;

    public float velProjectile = 10f;

    public float fireRate = 1.5f;

    private float nextFireTime = 0f;

    public void Shoot(Vector3 mousePos)
    {

        if(Time.time < nextFireTime)
        {
            return;
        }

        Vector2 dir = (Vector2)(mousePos - transform.position);
        dir.Normalize();

        float distanciaSegura = 0.8f;
        Vector3 posicaoDeSpawn = transform.position + (Vector3)(dir * distanciaSegura);

        GameObject fireBall = Instantiate(ProjectilePrefab, posicaoDeSpawn, Quaternion.identity);

        Rigidbody2D rb = fireBall.GetComponent<Rigidbody2D>();
        rb.velocity = dir * velProjectile;

        float angulo = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        fireBall.transform.rotation = Quaternion.Euler(0, 0, angulo);


        nextFireTime = Time.time + fireRate;
    }
    
}
