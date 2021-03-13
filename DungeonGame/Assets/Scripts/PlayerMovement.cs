using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Player Speed
    public float speed;
    private Rigidbody2D playerRB;
    private Vector2 velocity;

    void Start(){
        playerRB = GetComponent<Rigidbody2D>();
    }

    void Update(){
        // Get player's Key-press movement input
        Vector2 movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        // Calculate Velocity
        velocity = movementInput.normalized * speed;
    }

    void OnCollision2DEnter(){
        velocity = velocity * 0;
    }

    void FixedUpdate(){
        playerRB.MovePosition(playerRB.position + velocity * Time.fixedDeltaTime);
    }
}
