using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunOuterRotation : MonoBehaviour
{

    void Update()
    {
        transform.Rotate(new Vector3(-1f,-1f,0f) * Time.deltaTime);
    }
}
