using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    // Destroy all game objects that collide with this point
    void OnTriggerEnter2D(Collider2D collision){
        Destroy(collision.gameObject);
    }
}
