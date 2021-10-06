﻿using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    public float damage = 10;
    public float range = 100;
    public float knockBackForce;

    public GameObject sfxSpawn;

    public Animation gunSpin;

    public int maxAmmo;
    public int currentAmmo;

    public bool canShoot;

    public Camera cam;
    public ParticleSystem muzzleFlash;
    public GameObject gunShotSfx;

    public Text text;   
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            Shoot();
        }

        if (currentAmmo < maxAmmo && Input.GetKeyDown(KeyCode.R))     
        {
            Reload();
        }

        if(currentAmmo <= 0)
        {
            canShoot = false;
        }
        text.text = currentAmmo.ToString();
    }

    void Shoot()
    {
        muzzleFlash.Play();
        Instantiate(gunShotSfx, sfxSpawn.transform.position, sfxSpawn.transform.rotation);
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            currentAmmo -= 1;

            print("We Shot Something");
            Target target = hit.transform.GetComponent<Target>();
           
            if (target != null)
            {
                target.TakeDamage(damage);
            }
            else if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * knockBackForce);
            }
            
        }
    }
    void Reload()
    {
        canShoot = false;
        gunSpin.Play();             
    }
    void CanShoot()
    {
        canShoot = true;
        currentAmmo = maxAmmo;
    }
    void Start()
    {
        currentAmmo = maxAmmo;
        canShoot = true;
    }
}
