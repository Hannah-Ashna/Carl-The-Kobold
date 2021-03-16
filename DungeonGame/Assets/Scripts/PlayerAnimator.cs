using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    // Player Animation
    SpriteRenderer spriteRenderer;
    Animator animator;
    RuntimeAnimatorController idle;
    RuntimeAnimatorController walk;
    RuntimeAnimatorController attack;

    private bool flipSprite = false;

    void Start(){;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        idle = Resources.Load("Animations/PlayerIdle") as RuntimeAnimatorController;
        walk = Resources.Load("Animations/PlayerWalk") as RuntimeAnimatorController;
        attack = Resources.Load("Animations/PlayerAttack") as RuntimeAnimatorController;
    }

    void FixedUpdate(){
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Get Status from Player Damage to see if Player is engaged in combat
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDamage>().attackStatus()){
            animator.runtimeAnimatorController = attack;
        } else if (moveHorizontal < 0){
            // Flip Player to the Left
            flipSprite = true;
            animator.runtimeAnimatorController = walk;
        } else if (moveHorizontal > 0){
            // Flip Player to the Right
            flipSprite = false;
            animator.runtimeAnimatorController = walk;
        } else {
            // Idle Animation
            animator.runtimeAnimatorController = idle;
        }

        spriteRenderer.flipX = flipSprite;
    }

}