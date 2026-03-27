using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{


    public GameObject ProjectilePrefab;

    public Transform LaunchOffset;

    private Rigidbody2D _playerRigidBody2D;

    public float _playerSpeed;

    public float velProjectile = 10f;

    private Vector2 _playerDirection;

    // Start is called before the first frame update
    void Start()
    {
        _playerRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        // update each frame the player direction (position)

        _playerDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void FixedUpdate()
    {
        // Player movement
        _playerRigidBody2D.MovePosition(_playerRigidBody2D.position + _playerSpeed * Time.fixedDeltaTime * _playerDirection);
    }


void Shoot()
    {
        // Pega a posição do mouse e converte
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        // Calcula a direção baseada no centro do Mago (transform.position)
        Vector2 dir = (Vector2)(mousePos - transform.position);
        dir.Normalize();

        // A MÁGICA NOVA: Nascer a uma distância segura!
        // Como o seu CapsuleCollider2D tem tamanho X: 1, 
        // colocar a bola a 0.8f de distância garante que ela nasce fora do seu corpo.
        float distanciaSegura = 0.8f;
        Vector3 posicaoDeSpawn = transform.position + (Vector3)(dir * distanciaSegura);

        // Cria a bola nessa posição calculada fora do mago
        GameObject fireBall = Instantiate(ProjectilePrefab, posicaoDeSpawn, Quaternion.identity);

        // Dá a velocidade
        Rigidbody2D rb = fireBall.GetComponent<Rigidbody2D>();
        rb.velocity = dir * velProjectile;

        // Vira a arte
        float angulo = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        fireBall.transform.rotation = Quaternion.Euler(0, 0, angulo);
    }
    
}
