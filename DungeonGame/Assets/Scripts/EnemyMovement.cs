using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public float stopDist;
    public float retreatDist;
    private Transform player;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update(){
        if(Vector2.Distance(transform.position, player.position) < 6){
            if(Vector2.Distance(transform.position, player.position) > stopDist){
                // Follow the player up until defined distance
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime); 
            } 
            
            else if (Vector2.Distance(transform.position, player.position) > stopDist && Vector2.Distance(transform.position, player.position) > retreatDist){
                // Once point is reached, stay put
                transform.position = this.transform.position;
            }

            else if (Vector2.Distance(transform.position, player.position) < retreatDist) {
                // If player moves closer, retreat by specified value
                transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime); 
            }
        }
    }
}
