using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Entity : MonoBehaviour
{
    //////////////////////////
    /////////////////////////////
   public float health;
   public Detonator detonator; 
   
   private GameGUI gui;
   private Rigidbody rb;

   public AudioSource audioOne;
   
public void PlayAudio(){
  audioOne = GetComponent<AudioSource>();
  audioOne.Play();   
}

   public virtual void TakeDamage(float dmg){
       health -= dmg;
       Debug.Log(health);
       if(health <= 0){
       Invoke("PlayAudio", 0.9f);
       NavMeshAgent nav = GetComponent<NavMeshAgent>();
       Destroy(nav);
       gameObject.AddComponent(typeof(Rigidbody));
       rb = gameObject.GetComponent<Rigidbody>();
       Instantiate(detonator, rb.transform.position , Quaternion.identity);
       StartCoroutine("Die");
       }
   }

   public virtual void HealDamage(float hp){
        if(health <= 100){
           health += hp;
        }
   }


   IEnumerator Die(){
       yield return new WaitForSeconds(1);
       Instantiate(detonator, rb.transform.position , Quaternion.identity);
       yield return new WaitForSeconds(1);
       Destroy(gameObject);
   }

}
