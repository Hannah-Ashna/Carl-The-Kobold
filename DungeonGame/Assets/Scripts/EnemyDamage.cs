using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private float timeBetweenShots;
    private float startTimeBetweenShots;
    public GameObject projectile;
    private Transform player;

    void Start (){
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        startTimeBetweenShots = Random.Range(1f, 2f);
        timeBetweenShots = startTimeBetweenShots;
    }

    void Update(){
        if (Vector2.Distance(transform.position, player.position) < 6){
            if (timeBetweenShots <= 0){
                Instantiate(projectile, transform.position, player.rotation);
                timeBetweenShots = startTimeBetweenShots;
            }

            else {
                timeBetweenShots -= Time.deltaTime;
            }
        }

    }
}
