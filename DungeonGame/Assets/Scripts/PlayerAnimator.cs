using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    // Player Animation
    SpriteRenderer spriteRenderer;
    Animator animator;
    RuntimeAnimatorController idle;
    RuntimeAnimatorController WalkL;
    RuntimeAnimatorController WalkR;

    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        idle = Resources.Load("Animations/PlayerIdle") as RuntimeAnimatorController;
        WalkL = Resources.Load("Animations/PlayerWalkL") as RuntimeAnimatorController;
        WalkR = Resources.Load("Animations/PlayerWalkR") as RuntimeAnimatorController;
    }

    void FixedUpdate(){
        float moveHorizontal = Input.GetAxis("Horizontal");

        if (!Input.anyKey) {
            animator.runtimeAnimatorController = idle;
        }

        if (moveHorizontal < 0){
            animator.runtimeAnimatorController = WalkL;
        }

        if (moveHorizontal > 0){
            animator.runtimeAnimatorController = WalkR;
        }
    }
}