using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{


    public ProjectileBehaviour ProjectilePrefab;

    public Transform LaunchOffset;

    private Rigidbody2D _playerRigidBody2D;

    public float _playerSpeed;

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
            Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);
        }
    }

    void FixedUpdate()
    {
        // Player movement
        _playerRigidBody2D.MovePosition(_playerRigidBody2D.position + _playerSpeed * Time.fixedDeltaTime * _playerDirection);
    }
    
}
