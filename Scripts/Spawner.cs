using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    ///
    private Slider slider;
    public GameObject enemy;

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
        StartCoroutine("SpawningEnemies");

    }

    // Update is called once per frame
    void Update()
    {
        spawnWait = Random.Range(spawnLeastWait,spawnMostWait);
        if(minEnemies>=maxEnemies){
            stop = false;
            
        }
        else{
            stop = true;
        }
        
    }
    

    IEnumerator SpawningEnemies (){
     yield return new WaitForSeconds(startWait);
     while (stop){
        randEnemy = Random.Range(0,2);
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 1, Random.Range(-spawnValues.z, spawnValues.z));
        Instantiate(enemy,spawnPosition + transform.TransformPoint(0,0,0), gameObject.transform.rotation);

        minEnemies++;
        yield return null;
     }
   }
}
