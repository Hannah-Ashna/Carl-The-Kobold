using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private float timeBetweenShots;
    private float startTimeBetweenShots;
    public GameObject projectile;
    private Transform player;

    // Animation
    SpriteRenderer spriteRenderer;
    Animator animator;
    RuntimeAnimatorController attackAnim;
    RuntimeAnimatorController idleAnim;
    RuntimeAnimatorController walkAnim;

    void Start (){
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        startTimeBetweenShots = Random.Range(1f, 2f);
        timeBetweenShots = startTimeBetweenShots;

        // Animation Setup
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        attackAnim = Resources.Load("Animations/BossAttack") as RuntimeAnimatorController;
        idleAnim = Resources.Load("Animations/BossIdle") as RuntimeAnimatorController;
        walkAnim = Resources.Load("Animations/BossWalk") as RuntimeAnimatorController;
    }

    void Update(){
        if (Vector2.Distance(transform.position, player.position) < 6){
            if (timeBetweenShots <= 0){
                Instantiate(projectile, transform.position, player.rotation);
                timeBetweenShots = startTimeBetweenShots;
            }

            else {
                timeBetweenShots -= Time.deltaTime;
            }
        }
    }

    void FixedUpdate(){
        if(gameObject.name == "Boss"){
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            if (moveHorizontal < 0 || moveHorizontal > 0 || moveVertical < 0 || moveVertical > 0) {
                animator.runtimeAnimatorController = walkAnim;
            }
            else if (moveHorizontal == 0 && moveVertical == 0 && Vector2.Distance(transform.position, player.position) < 3) {
                animator.runtimeAnimatorController = attackAnim;
            }
            else {
                animator.runtimeAnimatorController = idleAnim;
            }
        }
    }
}
