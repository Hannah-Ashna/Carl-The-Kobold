using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamage : MonoBehaviour
{
    private float timeBetweenShots;
    private float startTimeBetweenShots;
    public GameObject projectile;
    private Transform player;
    private bool attackMade = false;

    // Animation
    SpriteRenderer spriteRenderer;
    Animator animator;
    RuntimeAnimatorController attackAnim;
    RuntimeAnimatorController idleAnim;

    void Start (){
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        startTimeBetweenShots = Random.Range(1f, 2f);
        timeBetweenShots = startTimeBetweenShots;

        // Animation Setup
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        attackAnim = Resources.Load("Animations/BossAttack") as RuntimeAnimatorController;
        idleAnim = Resources.Load("Animations/BossIdle") as RuntimeAnimatorController;
    }

    void Update(){
        if (Vector2.Distance(transform.position, player.position) < 6){
            if (timeBetweenShots <= 0){
                attackMade = true;
                Instantiate(projectile, transform.position, player.rotation);
                timeBetweenShots = startTimeBetweenShots;
            }

            else {
                attackMade = false;
                timeBetweenShots -= Time.deltaTime;
            }
        }
    }

    void FixedUpdate(){
        if (Vector2.Distance(transform.position, player.position) < 6){
            animator.runtimeAnimatorController = attackAnim;
        } else {
            animator.runtimeAnimatorController = idleAnim;
        }
    }
}
