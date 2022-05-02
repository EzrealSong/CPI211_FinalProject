using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSystem : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 30f;
    public float impactForce = 30f;


    public Camera fpsCam;
    public GameObject impactEffect;
    public GameObject muzzleFlash;


    public GameObject spawnPoint;

    private float nextTimeToFire;
    [HideInInspector]
    public int gunType;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && !(Input.GetKey(KeyCode.LeftControl)))

        {
            nextTimeToFire = Time.time + 1f / fireRate;
            setBooleanFire();
            //animator.SetBool("IsFiringAR", true);
            Shoot();
            playSound();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            unsetBooleanFire();
            //animator.SetBool("IsFiringAR", false);
        }
    }

    void Shoot()
    {

        GameObject muzzleEff = Instantiate(muzzleFlash, spawnPoint.transform.position, spawnPoint.transform.rotation);
        //Destroy(muzzleEff, 2f);
        

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                //animator.SetBool("IsFiringAR", false);

                target.TakeDamage(damage);
            }
            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(hit.normal);
            }
        }
    }
    void setBooleanFire()
    {
        if (animator.GetBool("IsAR") == true)
        {
            gunType = 1;
            animator.SetBool("IsARFiring", true);
        }
        else if (animator.GetBool("IsRevolver") == true)
        {
            gunType = 2;
            animator.SetBool("IsRevolverFiring", true);
        }
        else if (animator.GetBool("IsSMG") == true)
        {
            gunType = 3;
            animator.SetBool("IsSMGFiring", true);
        }
        else if (animator.GetBool("IsShotgun") == true)
        {
            gunType = 4;
            animator.SetBool("IsShotgunFiring", true);
        }
        else if (animator.GetBool("IsSniper") == true)
        {
            gunType = 5;
            animator.SetBool("IsSniperFiring", true);
        }
    }
    void unsetBooleanFire()
    {
        if (animator.GetBool("IsAR") == true)
        {
            animator.SetBool("IsARFiring", false);
        }
        else if (animator.GetBool("IsRevolver") == true)
        {
            animator.SetBool("IsRevolverFiring", false);
        }
        else if (animator.GetBool("IsSMG") == true)
        {
            animator.SetBool("IsSMGFiring", false);
        }
        else if (animator.GetBool("IsShotgun") == true)
        {
            animator.SetBool("IsShotgunFiring", false);
        }
        else if (animator.GetBool("IsSniper") == true)
        {
            animator.SetBool("IsSniperFiring", false);
        }
    }
    void playSound()
    {
        if(gunType == 1)
        {
            FindObjectOfType<AudioManager>().Play("AR Fire");
        } else if (gunType == 2)
        {
            FindObjectOfType<AudioManager>().Play("Shotgun Fire");
        } else if(gunType == 3)
        {
            FindObjectOfType<AudioManager>().Play("SMG Fire");
        } else if (gunType == 4)
        {
            FindObjectOfType<AudioManager>().Play("Shotgun Fire");
        } else if (gunType == 5)
        {
            FindObjectOfType<AudioManager>().Play("Sniper Fire");
        }
    }
    

}
