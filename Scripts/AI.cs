using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    private Vector3 randomDestination;
    NavMeshAgent theAgent;

    public int xPos ;
    public int zPos ;
     private Transform playerPos;
    private float damageDistance = 90f;
    public Gun gun;

    private Vector3 q;

    private bool attacking;

    private float distance;

    public float AISkill = 150f;
    

   
    
    void Start()
    {
        theAgent = GetComponent<NavMeshAgent>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

  
    void Update()
    {
        distance = Vector3.Distance(transform.position, playerPos.position);
        CheckForPlayer();
        ShootTheGun();
    }

    int GetRandomX(){
        return xPos = Random.Range(-450,451);
    }
    int GetRandomZ(){
        return zPos = Random.Range(-450,451);
    }
    void ShootTheGun(){
        if(Vector3.Distance(transform.position, playerPos.position)<= damageDistance){
        gun.Shoot();
        Vector3 q = playerPos.position - transform.position;
         q.y = 0.0f;
         transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(q), Time.deltaTime * AISkill);
        }
    }
    void CheckForPlayer(){
    if(distance < 150f ){
        theAgent.ResetPath();
        theAgent.SetDestination(playerPos.position);
    }else if(theAgent.velocity.x == 0 && theAgent.velocity.z==0){
        randomDestination = new Vector3(GetRandomX(),8,GetRandomZ());
        theAgent.SetDestination(randomDestination);
   }
  }
}
