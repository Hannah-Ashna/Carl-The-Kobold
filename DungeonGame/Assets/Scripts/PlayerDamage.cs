using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    private GameObject enemyObj;

    void Update()
    {
        // User attacks enemy by pressing space
        if (Input.GetKeyDown(KeyCode.Space)){
            print("space");
            attackEnemy();
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        // Check if the collision is with an enemy
        if (other.CompareTag("Enemy")){
            try {
                enemyObj = GameObject.FindGameObjectWithTag("Enemy");
                attackEnemy();
            } catch {
                // Value is NULL as there is no nearby enemy to attack
            }
        }
    }

    void attackEnemy(){
        // Damage the enemy by reducing its health
        enemyObj.GetComponent<EnemyData>().damageEnemy();
    }
}
