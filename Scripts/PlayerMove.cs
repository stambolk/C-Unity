using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public Gun gun;
    private Animator anim;
    private CharacterController charController;
    private CollisionFlags collisionFlags = CollisionFlags.None;
    private float moveSpeed = 40f;
    private float acceleration = 2f;
    private bool canMove;
    private bool finished_Movement = true;
    private Vector3 target_Pos = Vector3.zero;
    private Vector3 player_Move = Vector3.zero;
    private float player_ToPointDistance;
    private float height;
    private static object Instance;
    public GameObject warp;
    private float warpFactor = 5f;

    void Awake()
    {
        warp.SetActive(false);
        anim = GetComponent<Animator>();
        charController = GetComponent<CharacterController>();
       
    }

    void Update()
    {
       
        CheckIfFinishedMovement();
        
       
        if (Input.GetMouseButton(0))
        {
            gun.Shoot();
        }
    }

   

  

    void CheckIfFinishedMovement()
    {
        if (!finished_Movement)
        {
            
                finished_Movement = true;
                
        }
        else
        {
            MoveThePlayer();
            player_Move.y = 7.3f;
            collisionFlags = charController.Move(player_Move);
            
        }
    }

    void MoveThePlayer()
    {
      
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider is TerrainCollider)
                {
                                         
                    player_ToPointDistance = Vector3.Distance(transform.position, hit.point);
                    
                    if (player_ToPointDistance >= 0.1f)
                    {
                        canMove = true;
                        target_Pos = hit.point;
                    }

                }
            }
         // if mouse button down

        if (canMove)
        {
            
            Vector3 target_Temp = new Vector3(target_Pos.x, transform.position.y, target_Pos.z);
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(target_Temp - transform.position),
                2f * Time.deltaTime);
                player_Move = transform.forward * moveSpeed * Time.deltaTime;
                warp.SetActive(false);
            
            if(Input.GetKey(KeyCode.E)){
            player_Move = transform.right * moveSpeed * Time.deltaTime * acceleration*0.5f;
            warp.SetActive(false);
            } 
            if(Input.GetKey(KeyCode.Q)){
            player_Move = -transform.right * moveSpeed * Time.deltaTime *acceleration*0.5f ;
            warp.SetActive(false);
            } 

            if(Input.GetKey(KeyCode.LeftShift)){
            player_Move = transform.forward * moveSpeed * Time.deltaTime * acceleration;
            warp.SetActive(false);
                        if(Input.GetKey(KeyCode.E)){
            player_Move = transform.right * moveSpeed * Time.deltaTime * acceleration;
            warp.SetActive(false);
            } 
            if(Input.GetKey(KeyCode.Q)){
            player_Move = -transform.right * moveSpeed * Time.deltaTime *acceleration ;
            warp.SetActive(false);
            } 

            } 
          
             if(Input.GetKey(KeyCode.LeftShift)&&(Input.GetKey(KeyCode.Space))){
            player_Move = transform.forward * moveSpeed * Time.deltaTime * acceleration *warpFactor;
            
             if(warpFactor == 1 && (Input.GetKey(KeyCode.LeftShift)&&(Input.GetKey(KeyCode.Space)))){
                 StartCoroutine("Reset");
                 Input.ResetInputAxes();
             }else if (warpFactor == 5 && (Input.GetKey(KeyCode.LeftShift)&&(Input.GetKey(KeyCode.Space)))){
                  StartCoroutine("Warping");
                  warp.SetActive(true);
             }

            } 
            
            if (Vector3.Distance(transform.position, target_Pos) <= 0.1f)
            {
                canMove = false;
            }

        }
        else
        {
            player_Move.Set(0f, 0f, 0f);
            
        }
    }

    public bool FinishedMovement
    {
        get
        {
            return finished_Movement;
        }
        set
        {
            finished_Movement = value;
        }
    }

    public Vector3 TargetPosition
    {
        get
        {
            return target_Pos;
        }
        set
        {
            target_Pos = value;
        }
    }
    IEnumerator Warping(){  
        yield return new WaitForSeconds(1);
        warp.SetActive(false);
        warpFactor = 1;
    }
    IEnumerator Reset(){
        yield return new WaitForSeconds(5);
        warpFactor = 5;
    }
 

} 