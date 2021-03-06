﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoidSpawner : MonoBehaviour
{
    ///
    public GameObject[] enemies;
    public GameObject[] asteroids;
    public GameObject[] planets;
    public GameObject[] factories;
    ///
    public Vector3 spawnValues;
    public float spawnWait;
    public int startWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    
    public int maxEnemies = 1;
    public int minEnemies= 0;

    public bool stop = true;

    int randEnemy;

    void Start()
    {
        StartCoroutine("SpawningRoids");
    }

    // Update is called once per frame
    void Update()
    {
        if(minEnemies>=maxEnemies){
            stop = false;
            
        }
        else{
            stop = true;
        }
    }

    IEnumerator SpawningRoids (){
     yield return new WaitForSeconds(startWait);
     while (stop){
        randEnemy = Random.Range(0,8);
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), Random.Range(-spawnValues.z, spawnValues.z));
        Instantiate(enemies[randEnemy],spawnPosition + transform.TransformPoint(0,0,0), gameObject.transform.rotation);
        minEnemies++;
        yield return new WaitForSeconds(spawnWait);
     }
   }
}
