using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    // Destroy all game objects that collide with this point
    void OnTriggerEnter2D(Collider2D collision){
        if(!collision.CompareTag("Player") && !collision.CompareTag("Enemy")){
            Destroy(collision.gameObject);
        }
    }
}
