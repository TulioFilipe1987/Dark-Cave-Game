using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJumper : MonoBehaviour{

    private Rigidbody2D myBody;
    private Animator anim;

    [SerializeField]
    private float minJumpForce = 5f, maxJumpForce = 12f;

    [SerializeField]
    private float minWaitTime = 1.5f, maxWaitTime = 3.5f;

    private float jumpTimer;

    private bool canJump;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        jumpTimer = Time.time + Random.Range(minWaitTime, maxWaitTime);
    }

    private void Update()
    {

        //Debug.Log(myBody.velocity.magnitude);

        HandleJumping();
        HandleAnimation();
    }

    void HandleJumping(){

        if(Time.time > jumpTimer)
        {
            jumpTimer = Time.time + Random.Range(minWaitTime, maxWaitTime);
            jump();

        }

        if (myBody.velocity.magnitude == 0)// magnitude ?
            canJump = true;
    
    }


    void jump()
    {

        if(canJump)
        {
            canJump = false;
            myBody.velocity = new Vector2(0f, Random.Range(minJumpForce, maxJumpForce));
        }
    }

    void HandleAnimation(){ // a animação do personagem

        if (myBody.velocity.magnitude == 0)
            anim.SetBool(TagManager.JUMP_ANIMATION_PARAMETER, false);
        else
            anim.SetBool(TagManager.JUMP_ANIMATION_PARAMETER, true);


    }

}//Class
