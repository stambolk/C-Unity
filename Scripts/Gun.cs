using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public enum GunType
    {
        Semi, Burst, Auto
    };
    public LayerMask collisionMask;

    public float gunId;
    public GunType gunType;
    public float rpm;
    public float damage = 10;
    public Transform spawn;
    public Transform shellEjectionPoint;
    public Rigidbody shell;
    private LineRenderer tracer;

    public AudioSource audioData;
    
    private float secondsBetweenShots;
    private float nextPossibleShootTime;

     void Start()
    {
        secondsBetweenShots = 60 / rpm;
       if(GetComponent<LineRenderer>())
        {
            tracer = GetComponent<LineRenderer>();
        }
    }
    public void Shoot ()
    {
        if (canShoot()) { 

        Ray ray = new Ray(spawn.position, spawn.forward);
        audioData.Play(0);
        RaycastHit hit;
        float shotDistance = 77f;
        if(Physics.Raycast(ray, out hit, shotDistance, collisionMask)){
            shotDistance = hit.distance;
            if(hit.collider.GetComponent<Entity>()){
                hit.collider.GetComponent<Entity>().TakeDamage(damage);
                hit.transform.gameObject.GetComponent<Impact>().AddImpact(Vector3.Lerp(ray.direction,spawn.position, 0), 100);
            }
        }
            nextPossibleShootTime = Time.time + secondsBetweenShots;
            if (tracer)
            {
                StartCoroutine("RenderTracer", ray.direction * shotDistance);
            }
            Rigidbody newShell = Instantiate(shell, shellEjectionPoint.position, Quaternion.identity) as Rigidbody;
            newShell.AddForce(shellEjectionPoint.forward * Random.Range(150f, 200f));
        }
    }
        public void OnTriggerEnter(Collider other){
            Ray ray = new Ray(spawn.position, spawn.forward);
            RaycastHit hit;
            float shotDistance = 75f;
            if(Physics.Raycast(ray, out hit, shotDistance, collisionMask)){
            shotDistance = hit.distance;
            hit.transform.gameObject.GetComponent<Impact>().AddImpact(Vector3.Lerp(ray.direction,spawn.position, 0), 100);   
        }
   }
    public void ShootContinious()
    {
        if(gunType == GunType.Auto)
        {
            Shoot();
        }
    }
    private bool canShoot()
    {
        bool canShoot = true;
        if(Time.time < nextPossibleShootTime)
        {
            canShoot = false;
        }
        return canShoot;
    }
    IEnumerator RenderTracer(Vector3 hitPoint) 
    {
        tracer.enabled = true;
        tracer.SetPosition(0, spawn.position);
        tracer.SetPosition(1, spawn.position + hitPoint);
        yield return null;
        tracer.enabled = false;
    }
}
