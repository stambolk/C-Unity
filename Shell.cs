﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    private float lifeTime = 5;
    private Material mat;
    private Color originalCol;
    private float fadePercent;
    private float deathTime;
    private bool fading;
    void Start()
    {
        deathTime = Time.time + lifeTime;
        StartCoroutine("Fade");
    }

    IEnumerator Fade()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (fading)
            {
                fadePercent += Time.deltaTime;
                mat.color = Color.Lerp(originalCol, Color.clear, fadePercent);
                if(fadePercent >=1)
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                if (Time.time > deathTime)
                {
                    fading = true;
                }
            }
        }

    }
}
