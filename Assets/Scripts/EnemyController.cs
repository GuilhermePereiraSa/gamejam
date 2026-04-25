using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float speed = 3f;
    public float distanciaSegura = 5f;

    private Transform targetPlayer;
    private Rigidbody2D _rb;
    private ShooterRole shooter;
    private ShieldRole shielder;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        shooter = GetComponent<ShooterRole>();

        shielder = GetComponent<ShieldRole>();
    

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject)
        {
            targetPlayer = playerObject.transform;
        }
    
    }

    void Update()
    {
        if(targetPlayer == null)
        {
            return;
        }


        // Se shooter
        if(shooter && shooter.enabled)
        {
            shooter.Shoot(targetPlayer.position);
        }

        // Se shielder
        if(shielder && shielder.enabled)
        {

            shielder.AimShield(targetPlayer.position);
            shielder.TryActivateShield(targetPlayer.position);
        }
    }


    void FixedUpdate()
    {
        if(targetPlayer == null) return;

        float distanciaAteAlvo = Vector2.Distance(transform.position, targetPlayer.position);

        Vector2 direcaoPerseguir = (targetPlayer.position - transform.position).normalized;


        if(shooter && shooter.enabled)
        {
            if(distanciaAteAlvo >= distanciaSegura)
            {                     // (final - inicial) vector * (t)

                _rb.MovePosition(_rb.position + speed * Time.fixedDeltaTime * direcaoPerseguir);
            }
        }

        if(shielder && shielder.enabled)
        {
            if(distanciaAteAlvo >= distanciaSegura)
            {

                _rb.MovePosition(_rb.position + speed * Time.fixedDeltaTime * direcaoPerseguir); 
            }
        }
    }
}
