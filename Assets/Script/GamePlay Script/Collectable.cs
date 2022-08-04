using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField]
    private bool timeCollcetable;

    [SerializeField]
    private float collectatableValue = 15f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }






}//class
