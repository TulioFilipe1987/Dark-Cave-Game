using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateObject : MonoBehaviour
{
    // SCRIPT DA BALA DE TEIA 
    [SerializeField]
    private float deactivateTimer = 3f;// 3 segundos 

    
    private void Start(){// ate aqui tudo bem 6

        //Invoke("DeactivateGameObject", deactivateTimer); 
        //foi retirdo daqui pra o "onEnable()"
    }

    private void OnEnable()// first comand
    {
        Invoke("DeactivateGameObject", deactivateTimer);
    }

    private void OnDisable()
    {

        CancelInvoke("DeactivateGameObject");
    }
    void DeactivateGameObject() 
    {

        if (gameObject.activeInHierarchy)
        {
            CancelInvoke("DeactivateGameObject");
            gameObject.SetActive(false);// SIXTHY comnand depos do 2 "FOR// FICA FALSO E NÃO DESTROY
           
            // Destroy(gameObject);
        }

    }


    

}
