using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ProjectileBehaviour : MonoBehaviour
{

    public float Speed = 4.5f;
    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.right*Time.deltaTime * Speed;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
