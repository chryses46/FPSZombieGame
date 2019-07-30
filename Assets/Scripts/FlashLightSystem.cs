using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSystem : MonoBehaviour
{
    [SerializeField] float lightDecay = .05f;
    [SerializeField] float angleDecay = .5f;
    [SerializeField] float minimumAngle = 40f;

    Light flashLight;

    void Start()
    {
        flashLight = GetComponent<Light>();
    }
    

    private void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }

    public void RestoreLightAngle(float restoreAngle)
    {
        flashLight.spotAngle += restoreAngle;
    }

    public void RestoreLightIntesnity(float intensityAmount)
    {
        flashLight.intensity += intensityAmount;
    }
    
    private void DecreaseLightIntensity()
    {
        flashLight.intensity -= lightDecay * Time.deltaTime;
    }

    private void DecreaseLightAngle()
    {
        if(flashLight.spotAngle <= minimumAngle)
        {
            return;
        }
        else
        {
            flashLight.spotAngle -= angleDecay * Time.deltaTime;
        }
        
    }
}
