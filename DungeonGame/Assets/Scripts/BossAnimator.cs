using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimator : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Animator animator;
    RuntimeAnimatorController BAttack;
    RuntimeAnimatorController BIdle;
    RuntimeAnimatorController BWalk;
    private Transform player;

    void Update (){
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        BAttack = Resources.Load("Animations/BossAttack") as RuntimeAnimatorController;
        BIdle = Resources.Load("Animations/BossIdle") as RuntimeAnimatorController;
        BWalk = Resources.Load("Animations/BossWalk") as RuntimeAnimatorController;
    }

    void FixedUpdate(){
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Must have (Clone) as it's an instance of the Prefab
        if(gameObject.name == "Boss(Clone)"){
            if (moveHorizontal < 0 || moveHorizontal > 0 || moveVertical < 0 || moveVertical > 0) {
                animator.runtimeAnimatorController = BWalk;
            }
            else if (moveHorizontal == 0 && moveVertical == 0 && Vector2.Distance(transform.position, player.position) < 6) {
                animator.runtimeAnimatorController = BAttack;
            }
            else {
                animator.runtimeAnimatorController = BIdle;
            }
        }
    }
}
