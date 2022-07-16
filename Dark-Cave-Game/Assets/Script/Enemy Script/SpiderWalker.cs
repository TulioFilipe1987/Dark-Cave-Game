using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWalker : MonoBehaviour
{

    private SpriteRenderer spriteRen;

    private Transform groundCheckPos;

    [SerializeField]
    private LayerMask groundLayer;

    private RaycastHit2D groundHit;

    //Movements 
    [SerializeField]
    private float moveSpeed = 5f;

    private bool moveLeft;

    private Vector3 tempPos;
    private Vector3 tempScale;

    private float scaleXValue;

    // work wih distance
    [SerializeField]
    private float maxWalkDistanceValue = 10;// distance total

    private float minWalkX, maxWalkX;

    private void Awake()
    {
        spriteRen = GetComponent<SpriteRenderer>();
        groundCheckPos = transform.GetChild(0);

        moveLeft = Random.Range(0, 2) > 0 ? true : false;

        scaleXValue = transform.localScale.x; // ativar a escala
                                              //
        minWalkX = transform.position.x - maxWalkDistanceValue;
        maxWalkX = transform.position.x + maxWalkDistanceValue;


    }

    private void Update()
    {

        //HandleWalkingWithGroundCheck();
        //CheckForGround();
    }

    void CheckForGround(){ // estudar raycast

        groundHit = Physics2D.Raycast(groundCheckPos.position,
            Vector2.down, 0.1f, groundLayer);

        if (!groundHit)
            moveLeft = !moveLeft;

    }

    void HandleWalkingWithGroundCheck(){

        tempPos = transform.position;
        tempScale = transform.localScale;// ultimo agora 1

        //spriteRen.flipX = moveLeft; // ta liagdo?

        if(moveLeft)
        {
            tempPos.x -= moveSpeed * Time.deltaTime;
            tempScale.x =-scaleXValue;// a escala
        }
        else//(moveRight)
        {
            tempPos.x += moveSpeed * Time.deltaTime;
            tempScale.x = scaleXValue;
        }

        transform.position = tempPos;
        transform.localScale = tempScale;// ultimo agora 2

    }

    void HandleWalkingWithWalkDistance()
    {

        tempPos = transform.position;

        if (moveLeft)
        {
            tempPos.x -= moveSpeed * Time.deltaTime;
        }
        else
        {
            tempPos.x += moveSpeed * Time.deltaTime;
        }
    }


}//class
