using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    public float damage = 10;
    public float range = 100;
    public float knockBackForce;

    public Animation gunSpin;

    public GameObject reloadSFX;

    public int maxAmmo;
    public int currentAmmo;

    public bool canShoot;
    public bool outOfAmmo;

    public bool trail;
    public GameObject trailR;

    public Camera cam;
    public ParticleSystem muzzleFlash;
    public GameObject gunShotSfx;

    public Text text;   
    void Update()
    {
        if (PauseMenu.GameIsPaused)
        {
            canShoot = false;
        }
        else
        {
            canShoot = true;
        }
        if (Input.GetButtonDown("Fire1") && canShoot && !outOfAmmo)
        {
            Shoot();
        }

        if (currentAmmo < maxAmmo && Input.GetKeyDown(KeyCode.R))     
        {
            Reload();
        }

        if(currentAmmo <= 0)
        {
            outOfAmmo = true;
        }
        text.text = currentAmmo.ToString();
        if (trail)
        {
            trailR.SetActive(true);
        }
        else
        {
            trailR.SetActive(false);
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();
        Instantiate(gunShotSfx, transform.position, transform.rotation);
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
            
            if(hit.collider.tag == "Zombie")
            {
                //For Score Board
            }
        }
    }
    void Reload()
    {
        outOfAmmo = true;
        gunSpin.Play();             
    }
    void CanShoot()
    {
        outOfAmmo = false;
        currentAmmo = maxAmmo;
    }
    void Start()
    {
        currentAmmo = maxAmmo;
        canShoot = true;
    }
    void PlaySound()
    {
        Instantiate(reloadSFX, transform.position, transform.rotation);
    }
    void TOn()
    {
        trail = true;
    }
    void TOff()
    {
        trail = false;
    }
}
