using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour{

    public static GameplayController instance;

    [SerializeField]
    private Slider airSlider, timeSlider;

    [SerializeField]
    private float airMax = 20f, timeMax = 20f;//airTreshold = 20f  e timeTreshold = 20f

    private float airValue, timeValue;

    [SerializeField]
    private float airDeductValue = 1f;

    private bool gameRunnig;

    private void Awake(){

        if (instance == null)
            instance = this;
    }

    private void Start(){
        //timeValue
        timeValue = timeMax;

        timeSlider.maxValue = timeValue; // eu quero o maximo
        timeSlider.minValue = 0f;//eu quero o minimo
        timeSlider.value = timeValue;

        //AirValue
        airValue = airMax;

        airSlider.maxValue = airValue;
        airSlider.minValue = 0;
        airSlider.value = airValue;


        gameRunnig = true;

 }

    private void Update(){

        if (!gameRunnig)
            return;

        ReduceAir();
        ReduceTime();
    }

    void ReduceTime(){  // 

        timeValue -= Time.deltaTime;
        timeSlider.value = timeValue;

        if (timeValue <= 0f)
        {
            gameRunnig = false;
            //game over 


        }
    }

    void ReduceAir(){

        airValue -= airDeductValue * Time.deltaTime;
        airSlider.value = airValue;

        if(airValue <= 0f)
        {
            gameRunnig = false;
            //game over 
        }


    }



}// class
