using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{

    private int health = 100;
    private double sanity = 100;
    private float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 10f){
            sanity -= 0.5;

            print("Sanity Level: " + sanity);

            timer = 0;
        }
    }
}
