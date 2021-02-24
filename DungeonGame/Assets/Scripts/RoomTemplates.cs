using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
   // Arrays to categorise and store the different room prefabs
   public GameObject[] topRooms;
   public GameObject[] botRooms;
   public GameObject[] rightRooms;
   public GameObject[] leftRooms;
   public GameObject closedRoom;

   // Store a list of all the rooms generated
   public List<GameObject> rooms;

   // Spawn a Boss 
   public float waitTime;
   private bool spawnedBoss;
   private int rand;
   private int randX;
   private int randY;
   public GameObject Boss;
   public GameObject Minion;

   void Update(){
      if (waitTime <= 0 && spawnedBoss == false){
         for (int i = 1; i < rooms.Count; i++){

            rand = Random.Range(1, 4);
            Vector3 minionPos;

            for (int j = 0; j < rand; j++){
               randX = Random.Range(-5, 5);
               randY = Random.Range(-5, 5);
               minionPos = rooms[i].transform.position + new Vector3(randX, randY, 0);
               Instantiate(Minion, minionPos, Quaternion.identity);
            }

            if(i == rooms.Count-1){
               Instantiate(Boss, rooms[i].transform.position, Quaternion.identity);
               spawnedBoss = true;
            }
         }
      } else {
         waitTime -= Time.deltaTime;
      }
   }
}
