using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaShips : MonoBehaviour
{
    public int WhatShip = 0;

    void Update(){
        PickTheShip();
    }

    void PickTheShip(){
        switch(WhatShip){
            case 12:
            Debug.Log("You chose this");
            break;

            case 11:
            //CHOSE
            break;

            case 10:
            //CHOSE
            break;

            case 9:
            //CHOSE
            break;

            case 8:
            //CHOSE
            break;

            case 7:
            //CHOSE
            break;

            case 6:
            //CHOSE
            break;

            case 5:
            //CHOSE
            break;

            case 4:
            //CHOSE
            break;

            case 3:
            //CHOSE
            break;

            case 2:
            //CHOSE
            break;

            case 1:
            //CHOSE
            break;
            default:
            Debug.Log("Nothing chosen");
            break;
        }
    }
}
