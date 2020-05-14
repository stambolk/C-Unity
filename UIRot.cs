using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRot : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0f,7f,0f) * Time.deltaTime);
    }
}
