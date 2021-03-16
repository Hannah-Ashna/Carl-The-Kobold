using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyData : MonoBehaviour
{
    public double health;

    public bool damageEnemy(){
        // If enemy is still healthy, reduce their health
        if (health > 0) {
            health -= 5;

            return false;
        }

        // Otherwise kill them off
        else if (health == 0) {          
            KillEnemy();
            return true;
        }

        else {
            return false;
        }
    }

    void KillEnemy(){
        if (gameObject.name == "Boss(Clone)") {
            SceneManager.LoadScene("WinScene");
        }
        else {
            Destroy(gameObject); 
        }
    }
}
