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

    public bool moveLeft;// lll

    private Vector3 tempPos;
    private Vector3 tempScale;

    private float scaleXValue;

    // work wih distance
    [SerializeField]
    private float maxWalkDistanceValue = 10;// distance total

    private float minWalkX, maxWalkX;

    //isso vai limitar a dstancia de ida e volta
    [SerializeField]
    private bool walkWithGroundCheck;

   


    private void Awake()
    {
        spriteRen = GetComponent<SpriteRenderer>();
        groundCheckPos = transform.GetChild(0);

        moveLeft = Random.Range(0, 2) > 0 ? true : false;

        scaleXValue = transform.localScale.x; // ativar a escala
                                             
        minWalkX = transform.position.x - maxWalkDistanceValue;// -10
        maxWalkX = transform.position.x + maxWalkDistanceValue;// +10


    }

    private void Update(){

        HandleWalkingWithGroundCheck();
        CheckForGround();
        HandleWalkingWithWalkingDistance();



    }

    void CheckForGround(){ // estudar raycast

        groundHit = Physics2D.Raycast(groundCheckPos.position,
            Vector2.down, 0.1f, groundLayer);

        if (!groundHit)
            moveLeft = !moveLeft;

    }

    void HandleWalkingWithGroundCheck(){

        if (!walkWithGroundCheck)//useWalkDistance  True
            return;  // ele so sse move aonde tiver chao ,
                     // no caso esse chão é limitado de A ate B

        tempPos = transform.position;
        tempScale = transform.localScale;// ultimo agora 1 Serve paramover o ponto escala
 
       //spriteRen.flipX = moveLeft; // ta liagado?aqui era so munda o  flipx

        if (moveLeft)
        {
            tempPos.x -= moveSpeed * Time.deltaTime;
            tempScale.x = -scaleXValue;// a escala "recebe um valor"  
        
        }
        else//(moveRight)
        {
            tempPos.x += moveSpeed * Time.deltaTime;
            tempScale.x = scaleXValue;//"recebe um valor"
             
        }

        transform.position = tempPos;
        transform.localScale = tempScale;// ultimo agora 2

    }

    void HandleWalkingWithWalkingDistance()
    {
        if (walkWithGroundCheck)
            return;

        tempPos = transform.position;

        if(moveLeft)
        {
            tempPos.x -= moveSpeed * Time.deltaTime;
        }
        else
        {
            tempPos.x += moveSpeed * Time.deltaTime;
        }

        transform.position = tempPos;


        spriteRen.flipX = moveLeft;

        if (tempPos.x < minWalkX)
            moveLeft = false;// side right

        if (tempPos.x > maxWalkX)
            moveLeft = true; 
          
    
    }


      

}//class
