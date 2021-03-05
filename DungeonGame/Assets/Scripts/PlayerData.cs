using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerData : MonoBehaviour
{

    private int health = 100;
    private double sanity = 100;
    private float timer;
    private TextMeshProUGUI Score;

    void Start(){
        Score = GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 5f && sanity > 30){
            sanity -= 0.5;
            timer = 0;

            // Check if the sanity is below the desired level
            if (sanity <= 30){
                health = 0;
            }

            // Update the Game's Scoreboard
            Score.text = "Sanity: " + sanity + "\nHealth: " + health;
        }
    }
}
