using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageSC : MonoBehaviour
{
    private Player player;
    private bool inZone;

    public float TickRate = 1f;
    public float TickDamage = 1f;
    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.CompareTag("Player"))
		{
			inZone = false;
            Debug.Log(inZone);
		}
	}
    void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.CompareTag("Player"))
		{
			inZone = true;
            InvokeRepeating ("DamagePlayer", 0f, TickRate);
		}
	}
    void DamagePlayer(){
        if (inZone)
		{
			player.TakeDamage(TickDamage);
		}
	} 
   
}
