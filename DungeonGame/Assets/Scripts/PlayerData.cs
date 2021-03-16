using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
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

    void Update()
    {
        // Use timer to modify Sanity levels
        timer += Time.deltaTime;

        if (timer > 5f && sanity > 30){
            sanity -= 2.5;
            timer = 0;
            
            Score.text = "Sanity: " + sanity + "\nHealth: " + health;
            // Check if the sanity is below the desired level
            if (sanity <= 30){
                KillPlayer();
            }
        }

    }

    // Increase Health with a Potion
    public void HealthPotion(double val){
        double newHealth = health + val;
        if (newHealth > 100){
            health = 100;
        } else {
            health = newHealth;
        }
        Score.text = "Sanity: " + sanity + "\nHealth: " + health;
    }
    
    // Increase Sanity with a Potion
    public void SanityPotion(double val) {
        double newSanity = sanity + val;
        if (newSanity > 100){
            sanity = 100;
        } else {
            sanity = newSanity;
        }

        Score.text = "Sanity: " + sanity + "\nHealth: " + health;
    }

    // Reduce Health after an Attack - Or Kill Player
    public void ReduceHealth(int damage){
        if (health != 0) {
            health = health - damage;
            Score.text = "Sanity: " + sanity + "\nHealth: " + health;
        } else {
            KillPlayer();
        }
    }

    // Check what kind of loot was acquired and update player data
    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Loot")){ 
            if(other.gameObject.name == "Health(Clone)"){
                HealthPotion(20);
            } else if(other.gameObject.name == "Health2(Clone)"){;
                HealthPotion(40);
            } else if(other.gameObject.name == "Sanity(Clone)"){
                SanityPotion(20);
            } else if(other.gameObject.name == "Sanity2(Clone)"){
                SanityPotion(50);
            }

            // Destroy potion after consumption
            Destroy(other.gameObject);
        }
    }

    // Kill the Player
    void KillPlayer(){
        SceneManager.LoadScene("LoseScene");
    }

    // End the Game
    void EndGame(){
        SceneManager.LoadScene("WinScene");
    }
}
