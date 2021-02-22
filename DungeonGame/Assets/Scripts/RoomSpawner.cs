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

    void Update(){
        if(openingDirection == 1){
            // Spawn any room with a Bottom Door
        } else if (openingDirection == 2){
            // Spawn any room with a Top Door
        } else if (openingDirection == 3){
            // Spawn any room with a Left Door
        } else if (openingDirection == 4){
            // Spawn any room with a Right Door
        } else {
            print("Error");
        }
    }
}
