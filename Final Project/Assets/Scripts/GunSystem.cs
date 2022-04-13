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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
       
        GameObject muzzleEff = Instantiate(muzzleFlash, spawnPoint.transform.position, spawnPoint.transform.rotation);
        Destroy(muzzleEff, 2f);

        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }
            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 2f);
            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(hit.normal); 
            }
        }
    }

}
