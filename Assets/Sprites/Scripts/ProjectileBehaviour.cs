using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float Speed = 4.5f;
    public float lifeTime = 3f;

    private Vector2 _dir;

    void Start()
    {
        Destroy(gameObject, lifeTime);

        Collider2D projetilCollider = GetComponent<Collider2D>();
        Collider2D playerCollider = GameObject.FindWithTag("Player").GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(projetilCollider, playerCollider);
    }

    public void Launch(Vector2 dir)
    {
        _dir = dir;
    }

    void Update()
    {
        if (_dir != Vector2.zero)
        {
            transform.position += (Vector3)_dir * Time.deltaTime * Speed;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}