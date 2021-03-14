using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    public double health;

    void Update (){
        if (health == 0) {
            KillEnemy();
        }
    }

    public void damageEnemy(){
        if (health > 0) {
            health -= 5;
        }
    }

    void KillEnemy(){
        Destroy(gameObject);
    }
}
