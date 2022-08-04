using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderShooterPool : MonoBehaviour
{

    [SerializeField]
    private GameObject spiderBullet;

    [SerializeField]  // pode tira se quise o SerializeField
    private List<GameObject> bullets = new List<GameObject>();

    [SerializeField]
    private int initialBullets = 20;

    [SerializeField]
    private Transform bulletSpawnPos;

    [SerializeField]
    private float minShootWaitTime = 1f, maxShootWaitTime = 3f;

    private float waitTime;



    private void Awake()// second comand
    {
        CreateInitilaBullets();
    }

    private void Start() // thrird comand
    {
        waitTime = Time.time + Random.Range(minShootWaitTime, maxShootWaitTime);
    }

    private void Update()// forth comand
    {
        if (Time.time > waitTime)
        {
            waitTime = Time.time + Random.Range(minShootWaitTime, maxShootWaitTime);
            shoot();// esperando pra ser ativado
        }
        
    }

    void CreateInitilaBullets() // fisrt comand
    {
        for (int i= 0; i< initialBullets; i++) // vai coloar as balas
        {
            GameObject newBullet = Instantiate(spiderBullet);
            newBullet.SetActive(false);
            newBullet.transform.SetParent(transform);//colocou agra
            bullets.Add(newBullet);
        }


    }

    void shoot()// última função
    {

        /*for(int i= 0; i < bullets.Count; i++) 
        {
            if (!bullets[i].activeInHierarchy) 
            {
               bullets[i].SetActive(true);
               bullets[i].transform.position = bulletSpawnPos.position;
               break;
           }
        

       }*/

        foreach (GameObject bul in bullets)
        {

            if (!bul.activeInHierarchy)
            {
                bul.SetActive(true);
                bul.transform.position = bulletSpawnPos.position;
                break;

            }
        }


    }




}// class
