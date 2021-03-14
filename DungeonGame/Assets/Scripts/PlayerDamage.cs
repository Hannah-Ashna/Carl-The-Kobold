using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    private GameObject enemyObj;
    public bool nearEnemy = false;

    void Update() {
        // User attacks enemy by pressing space
        if (Input.GetKeyDown(KeyCode.Space) && nearEnemy == true){
            try {
                attackEnemy();
                print("HIT!");
            } catch {
                print("MISS!");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        // Check if the player is colliding with enemy
        if (other.CompareTag("Enemy")){
            // Targets the correct Enemy object instead of a random one
            enemyObj = other.gameObject;
            nearEnemy = true;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        // Check if the player is no longer colliding with enemy
        if (other.CompareTag("Enemy")){
            nearEnemy = false;
        }
    }

    void attackEnemy(){
        // Damage the enemy by reducing its health
        enemyObj.GetComponent<EnemyData>().damageEnemy();
    }
}
