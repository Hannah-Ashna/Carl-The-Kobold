using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionAnimator : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Animator animator;
    RuntimeAnimatorController MAttack;
    RuntimeAnimatorController MIdle;
    RuntimeAnimatorController MWalk;
    private Transform player;

    void Update (){
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        MAttack = Resources.Load("Animations/MinionAttack") as RuntimeAnimatorController;
        MIdle = Resources.Load("Animations/MinionIdle") as RuntimeAnimatorController;
        MWalk = Resources.Load("Animations/MinionWalk") as RuntimeAnimatorController;
    }

    void FixedUpdate(){
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Must have (Clone) as it's an instance of the Prefab
        if(gameObject.name == "Minion(Clone)"){
            try {
                if (moveHorizontal < 0 || moveHorizontal > 0 || moveVertical < 0 || moveVertical > 0) {
                     // Walking Animation
                    animator.runtimeAnimatorController = MWalk;
                } else if (moveHorizontal == 0 && moveVertical == 0 && Vector2.Distance(transform.position, player.position) < 6) {
                     // Attack Animation
                    animator.runtimeAnimatorController = MAttack;
                } else {
                     // Idle Animation
                    animator.runtimeAnimatorController = MIdle;
                }
            } catch{
                // Couldn't animate
            }
        }
    }
}
