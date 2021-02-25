using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    private Transform player;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update(){
        if(Vector2.Distance(transform.position, player.position) < 3.5 && Vector2.Distance(transform.position, player.position) > 3){
            Vector3 playerPos = player.position;
            transform.position = Vector2.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
        }
    }
}
