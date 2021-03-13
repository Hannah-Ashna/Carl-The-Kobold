using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private float timeBetweenShots;
    public float startTimeBetweenShots;
    public GameObject projectile;

    void Start (){
        timeBetweenShots = startTimeBetweenShots;
    }

    void Update(){
        if (timeBetweenShots <= 0){
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBetweenShots = startTimeBetweenShots;
        }

        else {
            timeBetweenShots -= Time.deltaTime;
        }
    }
}
