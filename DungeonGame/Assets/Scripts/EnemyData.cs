using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    private double health = 25;

    void Update (){
        //print(health);
    }

    public void damageEnemy(){
        if (health > 0) {
            health -= 5;
        }

        else {
            DestroyImmediate(gameObject);
        }  
    } 
}
