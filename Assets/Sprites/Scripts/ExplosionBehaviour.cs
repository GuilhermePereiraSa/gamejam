using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour
{
    public float lifeTime = 3f;
    public float initialScale = 3f;

    private float _tempoPassado = 0f;

    void Start()
    {
        transform.localScale = Vector3.one * initialScale;
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        _tempoPassado += Time.deltaTime;

        // t vai de 0 a 1 ao longo do lifeTime
        float t = _tempoPassado / lifeTime;

        // Scale vai de initialScale até 0
        transform.localScale = Vector3.one * Mathf.Lerp(initialScale, 0f, t);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player está dentro da explosão!");
        }
    }
}