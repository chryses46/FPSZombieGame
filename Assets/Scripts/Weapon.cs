using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 10f;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] float shootDelay = 1f;
    bool canShoot = true;
    
    void OnEnable()
    {
        canShoot = true;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    IEnumerator Shoot()
    {
        canShoot = false;

        if(ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            ProcessRaycast();
            PlayMuzzleFlash();
            ammoSlot.ReduceCurrentAmmo(ammoType);
        }

        yield return new WaitForSeconds(shootDelay);

        canShoot = true;
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range);
        if (hit.transform)
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impactEffect = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impactEffect, 1);
    }
}
