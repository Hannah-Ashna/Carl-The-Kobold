using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyData : MonoBehaviour
{
    public double health;

    public bool damageEnemy(){
        
        if (health > 0) {
            // If enemy is still healthy, reduce their health
            health -= 5;
            return false;
        } else if (health == 0) {
             // Otherwise kill them off      
            KillEnemy();
            return true;
        } else {
            return false;
        }
    }

    void KillEnemy(){
        if (gameObject.name == "Boss(Clone)") {
            // If the Dead enemy is the Boss, end the game - load Win Scene
            SceneManager.LoadScene("WinScene");
        }
        else {
            // Otherwise just destroy the minion enemy
            Destroy(gameObject); 
        }
    }
}
