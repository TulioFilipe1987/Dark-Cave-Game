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
    private float airDeductValue = 3f; // 3 segundos ate a volta 

    private bool gameRunnig;


    [SerializeField]
    private Canvas gameOverCanvas;

    [SerializeField]
    private Text winText, loseText;

    [SerializeField]
    private float restartLvTime = 3f;

    private GameObject player;


    

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

        player = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG);

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
            GameOver(false);


        }
    }

    void ReduceAir(){

        airValue -= airDeductValue * Time.deltaTime;
        airSlider.value = airValue;

        if(airValue <= 0f)
        {
            gameRunnig = false;
            GameOver(false);
            //game over 
        }


    }

    public void IncreaseAir(float air)
    {
        airValue += air;

        if (airValue > airMax)
            airValue = airMax;

    }

    public void IncreaseTime(float time)
    {
        timeValue += time;

        if (timeValue > timeMax)
            timeValue = timeMax;
    
    }

    

    void RestartLevel()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene
            (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void GameOver(bool win)
    {

        SoundController.instance.Play_GameOverSound();// gameover sound

        Destroy(player);
        gameOverCanvas.enabled = true;


        gameRunnig = false;

        if (win)
            winText.gameObject.SetActive(true);
        else
            loseText.gameObject.SetActive(true);

         Invoke("Restartleve", restartLvTime);
    }

    void Restartlevel(){

        UnityEngine.SceneManagement.SceneManager.LoadScene
            (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);


    }



}// class
