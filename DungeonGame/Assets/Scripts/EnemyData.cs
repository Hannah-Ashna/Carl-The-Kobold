using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    public double health;

    void Update (){
        //print(health);
    }

    public void damageEnemy(){
        if (health > 0) {
            health -= 5;
        }

        else {
            KillEnemy();
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player") && health == 0){
            KillEnemy();
        }
    }

    void KillEnemy(){
        Destroy(gameObject);
    }
}
