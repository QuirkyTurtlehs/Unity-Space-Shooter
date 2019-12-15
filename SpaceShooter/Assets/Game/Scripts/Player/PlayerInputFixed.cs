using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputFixed : MonoBehaviour
{
    //TODO: Readability change 
    /// <summary>
    /// Changed some field names because the were confusing/not clear enough, also changed the fields that doesn't need to be public to private (and serialized).
    /// Imo, if less fields are public it makes it easier trying to find what you're looking for when accessing the script from outside it.
    /// </summary>

    [SerializeField] private string horizontalInput = "Horizontal"; //Changed name from moveX to horizontalInput
    [SerializeField] private string verticalInput = "Vertical"; //Changed name from moveY to verticalInput
    [SerializeField] private string shootInput = "Shoot"; //Changed name from shoot to shootInput
    [SerializeField] private float speed;

    private Rigidbody2D rigidBody;
    private PlayerShootFixed playerShoot;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerShoot = GetComponent<PlayerShootFixed>();
    }

    void Update()
    {
        if (Input.GetButtonDown(shootInput))
        {
            //TODO: bad/slow code
            ///<summary> 
            /// Was getting the PlayerShoot script here for some reason. Moved it to start and made playerShoot a global field
            ///</summary>
        
            playerShoot.ShootLaser();
        }
    }

    void FixedUpdate()
    {
        //TODO: Readability change
        float horizontalMovement = Input.GetAxis(horizontalInput); //Changed name from movementX to horizontalMovement

        //TODO: Readability change
        float verticalMovement = Input.GetAxis(verticalInput); //Changed name from movementX to verticalMovement

        //TODO: Readability change
        Vector3 finalMovement = new Vector3(horizontalMovement, verticalMovement, transform.position.z); //changed name from movement to finalMovement

        //TODO: Bad code
        ///<summary> 
        /// Added "* Time.fixedDeltaTime" so the movement isn't reliant on frame rate.
        ///</summary>
        rigidBody.MovePosition(transform.position + finalMovement * speed * Time.fixedDeltaTime);
    }
}

