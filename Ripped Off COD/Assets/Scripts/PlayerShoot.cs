using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float damage = 10;
    public float range = 100;
    public float knockBackForce;

    public Camera cam;
    public ParticleSystem muzzleFlash;
    public GameObject gunShotSfx;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();
        Instantiate(gunShotSfx, transform.position, transform.rotation);
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
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
}
