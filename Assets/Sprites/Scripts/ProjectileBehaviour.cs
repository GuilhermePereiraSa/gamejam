using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float Speed = 4.5f;

    // Vida do projetil - ou quantas vezes ele ricocheteia nas paredes;
    public float lifeTime = 3f;

    private Vector2 _lastVelocity; // MEMORIA DA VELOCIDADE ANTES DE BATER
    // para a bola de fogo nao ficar presa na parede

    private Rigidbody2D _rb;

    private Vector2 _dir;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>(); // movido para cá
    }

    void Start()
    {
        // _rb = GetComponent<Rigidbody2D>(); remove daqui
        Destroy(gameObject, lifeTime);

        Collider2D projetilCollider = GetComponent<Collider2D>();
        Collider2D playerCollider = GameObject.FindWithTag("Player").GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(projetilCollider, playerCollider);
    }

    public void Launch(Vector2 dir)
    {
        _rb.velocity = dir * Speed; // agora o _rb já existe
    }

    void Update()
    {
        _lastVelocity = _rb.velocity;
        
        if (_rb.velocity != Vector2.zero)
        {
            float angulo = Mathf.Atan2(_rb.velocity.y, _rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angulo);
        }
    }


   void OnCollisionEnter2D(Collision2D collision)
    {
        // // Se bater em algo com a tag de "Reflect"
        // if (collision.gameObject.CompareTag("Reflect"))
        // {
        //     // Qual era a força e a direção ANTES da batida?
        //     float speed = _lastVelocity.magnitude;
        //     Vector2 direction = _lastVelocity.normalized;

        //     // Pega o ângulo da parede
        //     Vector2 normalParede = collision.contacts[0].normal;

        //     // Calcula o ricochete usando a direção antiga
        //     Vector2 direcaoRefletida = Vector2.Reflect(direction, normalParede);

        //     // Devolve a velocidade para a bola, forçando-a a ir para a nova direção!
        //     _rb.velocity = direcaoRefletida * Mathf.Max(speed, 0f);

        //     // Gira a arte do fogo para ficar bonita
        //     float angulo = Mathf.Atan2(_rb.velocity.y, _rb.velocity.x) * Mathf.Rad2Deg;
        //     transform.rotation = Quaternion.Euler(0, 0, angulo);
        // }
        // else
        // {

            Health healthTarget = collision.gameObject.GetComponent<Health>();

            // Tem algo nele? é o player
            if(healthTarget != null)
            {  
                healthTarget.TakeDamage(1);
            }

            // Bater no Mago ou qualquer outra coisa, se destroi
            Destroy(gameObject);
        //}
    }
}