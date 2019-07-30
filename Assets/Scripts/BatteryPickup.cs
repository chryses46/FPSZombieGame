using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float angleIncrease = 2;
    [SerializeField] float intensityIncrease = 1;
    FlashLightSystem flashLight;

    void Start()
    {
        flashLight = FindObjectOfType<FlashLightSystem>();
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            flashLight.RestoreLightAngle(angleIncrease);
            flashLight.RestoreLightIntesnity(intensityIncrease);
            Destroy(gameObject);
        }
    }
}
