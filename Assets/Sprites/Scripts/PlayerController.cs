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

    private DashController dashRef;
    private ShooterRole shooter;
    private ShieldRole shielder;

    // Start is called before the first frame update
    void Start()
    {
        _playerRigidBody2D = GetComponent<Rigidbody2D>();

        shooter = GetComponent<ShooterRole>();
        shielder = GetComponent<ShieldRole>();

        dashRef = GetComponent<DashController>();
    }

    // Update is called once per frame
    void Update()
    {       

        if(dashRef && dashRef.GetisDashing()) return;

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
            // ? or rotate shield? -> put shield on Origin player-IA 
            shielder.AimShield(mousePos);


            // Shielder Abilities 
            if (Input.GetKeyDown(KeyCode.E))
            {
                shielder.TryActivateShield(mousePos);
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                dashRef.TryDash(mousePos);
            }
        }
    }

    void FixedUpdate()
    {

        if(dashRef && dashRef.GetisDashing()) return;

        // Player movement
        _playerRigidBody2D.MovePosition(_playerRigidBody2D.position + _playerSpeed * Time.fixedDeltaTime * _playerDirection);
    }


    
}