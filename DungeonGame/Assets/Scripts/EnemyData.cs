using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    public double health;

    public void damageEnemy(){
        // If enemy is still healthy, reduce their health
        if (health > 0) {
            health -= 5;
        }

        // Otherwise kill them off
        if (health == 0) {
             KillEnemy();
        }
    }

    void KillEnemy(){
        Destroy(gameObject);
    }
}
