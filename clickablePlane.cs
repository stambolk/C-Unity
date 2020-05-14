using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickablePlane : MetaShips
{
    private GameObject ship;
    public Camera thisCamera;

    private Vector3 scaleChange = new Vector3(1.2f,1.2f,1.2f);
    // Start is called before the first frame update
    void Start()
    {
        ship = gameObject;
    }

    void OnMouseDown(){
        WhatShip = 12;
        gameObject.transform.localScale += scaleChange;
        scaleChange = new Vector3(0f,0f,0f);
    }
}
