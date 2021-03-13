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
            DestroyImmediate(gameObject);
        }  
    } 
}
