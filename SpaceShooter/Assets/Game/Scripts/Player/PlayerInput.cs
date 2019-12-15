using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public string moveX = "moveX";
    public string moveY = "moveY";
    public string shoot = "shoot";
    public float speed;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {        
        if (Input.GetButtonDown(shoot))
        {
            PlayerShoot ps = GetComponent<PlayerShoot>();
            ps.ShootLaser();
        }
    }
    void FixedUpdate()
    {       
        float movementX = Input.GetAxis(moveX);
        float movementY = Input.GetAxis(moveY);

        Vector3 movement = new Vector3(movementX, movementY, transform.position.z); 


        rb.MovePosition(transform.position + movement * speed);
    }
}
