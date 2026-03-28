using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{


    public GameObject ProjectilePrefab;

    private Rigidbody2D _playerRigidBody2D;

    public float _playerSpeed;

    private Vector2 _playerDirection;


    private ShooterRole shooter;
    private ShieldRole shielder;

    // Start is called before the first frame update
    void Start()
    {
        _playerRigidBody2D = GetComponent<Rigidbody2D>();

        shooter = GetComponent<ShooterRole>();
        shielder = GetComponent<ShieldRole>();
    }

    // Update is called once per frame
    void Update()
    {

        // update each frame the player direction (position)

        _playerDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        if(shooter && shooter.enabled)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                shooter.Shoot(mousePos);
            }
        }

        if(shielder && shielder.enabled)
        {
            
            shielder.AimShield(mousePos);

            if (Input.GetKeyDown(KeyCode.E))
            {
                shielder.TryActivateShield(mousePos);
            }
        }
    }

    void FixedUpdate()
    {
        // Player movement
        _playerRigidBody2D.MovePosition(_playerRigidBody2D.position + _playerSpeed * Time.fixedDeltaTime * _playerDirection);
    }


    
}
