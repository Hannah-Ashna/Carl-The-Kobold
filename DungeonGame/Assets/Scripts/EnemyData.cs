using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    private double health = 25;
    private bool destroyEnemy = false;
    void Update (){
        if (destroyEnemy == true) {
            KillEnemy();
        }
    }

    public void damageEnemy(){
        print(health);
        if (health > 0) {
            health -= 5;
        }

        if (health == 0) {
             KillEnemy();
        }
    }

    void KillEnemy(){
        Destroy(gameObject);
    }
}
