﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed;
    private Transform player;
    private GameObject playerObj;
    private Vector2 target;
    

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerObj = GameObject.FindGameObjectWithTag("Player");
        target = new Vector2(player.position.x, player.position.y);
    }

    void Update(){
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        // Check if projectile reaches player
        if (transform.position.x == target.x && transform.position.y == target.y){
            DestroyProjectile();
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player")){
            playerObj.GetComponent<PlayerData>().ReduceHealth();
            DestroyProjectile();
        }
    }

    void DestroyProjectile(){
        Destroy(gameObject);
    }
}
