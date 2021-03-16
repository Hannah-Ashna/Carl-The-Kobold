using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    private GameObject enemyObj;
    private Loot loot;
    private bool isEnemyDead = false;
    private bool isAttacking = false;
    public bool nearEnemy = false;

    void Start(){
        loot = GameObject.FindGameObjectWithTag("Loot").GetComponent<Loot>();
    }

    void Update() {
        // User attacks enemy by pressing space
        
        if (Input.GetKeyDown(KeyCode.Space) && nearEnemy == true){
            try {
                attackEnemy();  
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
            isAttacking = true;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        // Check if the player is no longer colliding with enemy
        if (other.CompareTag("Enemy")){
            nearEnemy = false;
            isAttacking = false;
        }
    }

    void attackEnemy(){
        // Damage the enemy by reducing its health
        isEnemyDead = enemyObj.GetComponent<EnemyData>().damageEnemy();
        // Drop some Loot if Enemy is Dead
        if (isEnemyDead == true){
            // Randomise Loot Chance
            int chance = Random.Range(1, 10);
            if (chance == 1) {
                // Spawn Super Health Potion
                Instantiate(loot.Potions[1], enemyObj.transform.position, Quaternion.identity);
            } else if (chance == 10) {
                // Spawn Super Sanity Potion
                Instantiate(loot.Potions[3], enemyObj.transform.position, Quaternion.identity);
            } else if (chance < 5){
                // Spawn Normal Health Potion
                Instantiate(loot.Potions[0], enemyObj.transform.position, Quaternion.identity);
            } else if (chance > 8) {
                // Spawn Normal Sanity Potion
                Instantiate(loot.Potions[2], enemyObj.transform.position, Quaternion.identity);
            } else {
                // Spawn Nothing
            }
            
            // Reset Status
            isEnemyDead = false;
        }
    }

    public bool attackStatus (){
        return isAttacking;
    }
}
