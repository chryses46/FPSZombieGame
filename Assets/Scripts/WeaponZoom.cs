using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{

    [SerializeField] Camera mainCamera;
    [SerializeField] RigidbodyFirstPersonController rbfps;
    [SerializeField] float zoomedFOV = 40f;
    [SerializeField] float defaultFOV = 60f;
    [SerializeField] float zoomedInSensitivity = 1f;
    [SerializeField] float zoomedOutSensitivity = 2f;

    float initXSensitivity;
    float initYSensitivity;

    bool zoomedIn;

    void OnDisable()
    {
        ZoomedOut();
    }

    void Update()
    {
        ControlZoom();
    }

    public void ControlZoom()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            switch(zoomedIn)
            {
                case false:
                    ZoomedIn();
                    break;
                case true:
                    ZoomedOut();
                    break;
                default:
                    break;
            }
            
        }
    }

    public void ZoomedIn()
    {
        zoomedIn = true;
        mainCamera.fieldOfView = zoomedFOV;
        rbfps.mouseLook.XSensitivity = zoomedInSensitivity;
        rbfps.mouseLook.YSensitivity = zoomedInSensitivity;
    }

    public void ZoomedOut()
    {
        zoomedIn = false;
        mainCamera.fieldOfView = defaultFOV;
        rbfps.mouseLook.XSensitivity = zoomedOutSensitivity;
        rbfps.mouseLook.YSensitivity = zoomedOutSensitivity;
    }

}
