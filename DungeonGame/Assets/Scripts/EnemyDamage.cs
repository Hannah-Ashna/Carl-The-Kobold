using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private float timeBetweenShots;
    private float startTimeBetweenShots;
    public GameObject projectile;

    void Start (){
        startTimeBetweenShots = Random.Range(1f, 2f);
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
