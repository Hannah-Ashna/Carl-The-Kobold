using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    // 1 - Bottom Door
    // 2 - Top Door
    // 3 - Left Door
    // 4 - Right Door

    private RoomTemplates templates;
    private int rand;
    private bool spawned = false;
    void Start(){
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("SpawnRoom", 0.7f);
    }

    void SpawnRoom(){
        // Check if a room has already been spawned, if not then spawn room
        // Used to prevent extra rooms from being spawned within the scene
        if (spawned == false) {
            if(openingDirection == 1){
                // Spawn any room with a Bottom Door
                rand = Random.Range(0, templates.botRooms.Length);
                Instantiate(templates.botRooms[rand], transform.position, templates.botRooms[rand].transform.rotation);
            } else if (openingDirection == 2){
                // Spawn any room with a Top Door
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
            } else if (openingDirection == 3){
                // Spawn any room with a Left Door
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
            } else if (openingDirection == 4){
                // Spawn any room with a Right Door
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
            } else {
                print("Error");
            }

            spawned = true;
        }
    }

    // Prevent rooms from being spawned on top of each other
    void onTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("SpawnPoint") && collision.GetComponent<RoomSpawner>().spawned == true){
            Destroy(gameObject);
        }
    }
}
