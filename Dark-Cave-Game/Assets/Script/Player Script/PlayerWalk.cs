using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed = 6f, jumpForce = 10f;

    private Rigidbody2D myBody;

    private Vector3 tempPos;

    private PlayerAnimation playerAnim; // other script

    [SerializeField]
    private LayerMask groundLayer;

    [SerializeField]
    private Transform groundCheckPos;

    private BoxCollider2D BoxCol2D;
     


    private void Awake(){

        myBody = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<PlayerAnimation>();
        BoxCol2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        //HandleMovementWithTransform();

        HandlePlayerAnimations();

        HandleJumping();
    }
    private void FixedUpdate()
    {
        HandleMovementWithRigidBody();
    }


    void HandleMovementWithTransform()
    {

        tempPos = transform.position;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {

            tempPos.x -= moveSpeed * Time.deltaTime;

        }

        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {

            tempPos.x += moveSpeed * Time.deltaTime;
        }

        
        
        transform.position = tempPos;
    }

    void HandleMovementWithRigidBody() {

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {

            myBody.velocity = new Vector2(-moveSpeed, myBody.velocity.y);

            //myBody.AddForce(new Vector2(-moveSpeed, 0f), ForceMode2D.Impulse);
           // playerAnim.Play_WalkAnimation(1);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {

            myBody.velocity = new Vector2(moveSpeed, myBody.velocity.y);

            //myBody.AddForce(new Vector2(moveSpeed, 0f), ForceMode2D.Impulse);
            //playerAnim.Play_WalkAnimation(1);
        }
       else
            myBody.velocity = new Vector2(0f, myBody.velocity.y);
        //playerAnim.Play_WalkAnimation(0);

    }

    void HandlePlayerAnimations(){

        playerAnim.Play_WalkAnimation((int)Mathf.Abs(myBody.velocity.x)); //converstion wih value absolute
        //playerAnim.Play_WalkAnimation((int)myBody.velocity.x);// converstion within abs

         playerAnim.SetFacingDirection((int)myBody.velocity.x);

         playerAnim.Play_JumpAnimation(!IsGrounded());  // estudar 1

    }

    bool IsGrounded(){

        //Debug.DrawRay(groundCheckPos.position, Vector2.down * 0.1f, Color.blue);

        // return Physics2D.Raycast(groundCheckPos.position, Vector2.down, 0.1f,
        // groundLayer);

        return Physics2D.BoxCast(BoxCol2D.bounds.center,  // estudar 2
           BoxCol2D.bounds.size, 0f, Vector2.down, 0.1f, groundLayer);
    
    }


    void HandleJumping(){

        

        if (Input.GetButtonDown(TagManager.JUMP_BUTTON))
        {
            if(IsGrounded())
            {
                myBody.velocity = new Vector2(myBody.velocity.x, jumpForce);

            }
        
        
        }
    
    }

}//class
