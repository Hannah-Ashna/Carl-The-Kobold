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
   public GameObject Boss;
   public GameObject Minion;
   void Update(){
      if (waitTime <= 0 && spawnedBoss == false){
         for (int i = 0; i < rooms.Count; i++){
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
