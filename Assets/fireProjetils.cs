using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireProjetils : MonoBehaviour
{

    public GameObject prefabFireBall;
    public Transform origin;
    public float velProjetile;
    public float lifeTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(prefabFireBall, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.CompareTag("Inimigo"))
        {
            Destroy(prefabFireBall, lifeTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        Vector2 dir = (Vector2)(mousePos - origin.position);
        dir.Normalize();


        GameObject fireBall = Instantiate(prefabFireBall, origin.position, Quaternion.identity);
        Rigidbody2D rb = fireBall.GetComponent<Rigidbody2D>();
        rb.velocity = dir * velProjetile;

        float angulo = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        fireBall.transform.rotation = Quaternion.Euler(0, 0, angulo);
    }
}
