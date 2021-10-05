using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float damage = 10;
    public float range = 100;
    public float knockBackForce;
    public float rotationSpeed = 15;

    public int _rotationSpeed = 15;

    public GameObject gun;

    public int maxAmmo;
    public int currentAmmo;

    public bool canShoot;

    public Camera cam;
    public ParticleSystem muzzleFlash;
    public GameObject gunShotSfx;
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            Shoot();
        }

        if (!canShoot && Input.GetKeyDown(KeyCode.R))     
        {
            Reload();
        }

        if(currentAmmo <= 0)
        {
            canShoot = false;
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
            
        }
    }
    void Reload()
    {
        //will fix later
        //gun.transform.Rotate(_rotationSpeed * Time.deltaTime, 0 , 0);
        
        currentAmmo = maxAmmo;
        canShoot = true;
    }
    void Start()
    {
        currentAmmo = maxAmmo;
        canShoot = true;
    }
}
