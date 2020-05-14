using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0f,7f,7f) * Time.deltaTime);
    }
}
