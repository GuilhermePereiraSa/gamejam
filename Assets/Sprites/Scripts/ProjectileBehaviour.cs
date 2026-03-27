using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ProjectileBehaviour : MonoBehaviour
{

    public float Speed = 4.5f;

    // Vida do projetil - ou quantas vezes ele ricocheteia nas paredes;
    public float lifeTime = 3f;

    private Vector2 _lastVelocity; // MEMORIA DA VELOCIDADE ANTES DE BATER
    // para a bola de fogo nao ficar presa na parede

    private Rigidbody2D _rb;
    // Update is called once per frame


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();


        // se destroi passados 3
        Destroy(gameObject, lifeTime);
    }

    void FixedUpdate()
    {
        // pegamos ela 1 frame antes
        _lastVelocity = _rb.velocity;
    }

   void OnCollisionEnter2D(Collision2D collision)
    {
        // Se bater em algo com a tag de "Reflect"
        if (collision.gameObject.CompareTag("Reflect"))
        {
            // Qual era a força e a direção ANTES da batida?
            float speed = _lastVelocity.magnitude;
            Vector2 direction = _lastVelocity.normalized;

            // Pega o ângulo da parede
            Vector2 normalParede = collision.contacts[0].normal;

            // Calcula o ricochete usando a direção antiga
            Vector2 direcaoRefletida = Vector2.Reflect(direction, normalParede);

            // Devolve a velocidade para a bola, forçando-a a ir para a nova direção!
            _rb.velocity = direcaoRefletida * Mathf.Max(speed, 0f);

            // Gira a arte do fogo para ficar bonita
            float angulo = Mathf.Atan2(_rb.velocity.y, _rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angulo);
        }
        else
        {
            // Bater no Mago ou qualquer outra coisa, se destroi
            Destroy(gameObject);
        }
    }
}
