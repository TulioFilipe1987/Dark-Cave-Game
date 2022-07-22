using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangingSpike : MonoBehaviour
{

    private Rigidbody2D myBody;

    [SerializeField]
    private LayerMask playerLayer;

    private RaycastHit2D playerHit;
    private bool playerDectected;

    private void Awake(){

        myBody = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        DetectPlayer();
    }

    private void OnDisable()
    {
        CancelInvoke("DeactivateObject");
    }

    void DetectPlayer()
    {

        if (playerDectected) // dont undested here 
            return; // aqvui quando ta falso ele nao desativ, so detecta

        playerHit = Physics2D.Raycast(transform.position, Vector2.down,
            100f, playerLayer); // O tamanho do limite esta 100

        Debug.DrawRay(transform.position, Vector2.down * 100f, Color.blue);



        if(playerHit)
        {
            playerDectected = true;// aqui quando fica true ele cai e se detroi em 3 segundos 
            Invoke("DeactivateObject", 3f);
            myBody.gravityScale = 1f;// gravity escle 1 é caindo
        }

    }

    void DeactivateObject()
    {
        gameObject.SetActive(false);
    }

}//class
