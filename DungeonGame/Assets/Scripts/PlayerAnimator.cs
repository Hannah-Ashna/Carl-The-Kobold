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
    private bool attackEnemy = false;

    void Start(){;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        idle = Resources.Load("Animations/PlayerIdle") as RuntimeAnimatorController;
        walk = Resources.Load("Animations/PlayerWalk") as RuntimeAnimatorController;
        attack = Resources.Load("Animations/PlayerAttack") as RuntimeAnimatorController;
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            attackEnemy = true;
        } else if (Input.GetKeyUp(KeyCode.Space)) {
            attackEnemy = false;
        }
    }
    void FixedUpdate(){
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        if (attackEnemy == true){
            print("wack");
            animator.runtimeAnimatorController = attack;
        }

        else if (moveHorizontal < 0){
            flipSprite = true;
            animator.runtimeAnimatorController = walk;

        }

        else if (moveHorizontal > 0){
            flipSprite = false;
            animator.runtimeAnimatorController = walk;
        }

        else {
            animator.runtimeAnimatorController = idle;
        }

        spriteRenderer.flipX = flipSprite;
    }
}