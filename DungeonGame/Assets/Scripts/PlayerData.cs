using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerData : MonoBehaviour
{

    public double sanity;
    public double health; 
    private float timer;
    private TextMeshProUGUI Score;
    private GameObject player;

    void Start(){
        Score = GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshProUGUI>();
        player = GameObject.FindGameObjectWithTag("Player");
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
                KillPlayer();
            }
        }

    }

    public void ReduceHealth(){
        if (health != 0) {
            health = health - 0.5;
            Score.text = "Sanity: " + sanity + "\nHealth: " + health;
        }

        else {
            KillPlayer();
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player")){
            KillPlayer();
        }
    }

    void KillPlayer(){
        //Destroy(player);
    }
}
