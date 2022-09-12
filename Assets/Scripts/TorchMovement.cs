using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
public class TorchMovement : MonoBehaviour
{
    Light2D light;
    [SerializeField] bool increaseIntensity;

    void Awake()
    {
        light = GetComponent<Light2D>();
    }
    private void Update()
    {
        if (!increaseIntensity)
        {
            light.intensity -= .01f;

            if (light.intensity <= 0.5f)
            {
                increaseIntensity = true;
            }
        }
        if (increaseIntensity)
        {
            light.intensity += .01f;

            if (light.intensity >= 1.1f)
            {
                increaseIntensity = false;
            }
        }
    }
}
