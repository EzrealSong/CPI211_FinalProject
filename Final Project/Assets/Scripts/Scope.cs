using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour
{
    public Animator animator;
    private bool isScoped = false;

    public GameObject scopeOverlay;
    public GameObject weaponCamera;
    public Camera mainCamera;

    public GameObject weaponController;

    public float scopedFOV = 15f;
    private float normalFOV;

    void Update()
    {

        if (Input.GetButtonDown("Fire2"))
        {
            isScoped = !isScoped;
            animator.SetBool("IsScoped", true);

            if (isScoped)
            {
                StartCoroutine(OnScoped());
            }
            else
            {
                onUnscoped();
                animator.SetBool("IsScoped", false);
            }
        }
    }
    void onUnscoped()
    {
        scopeOverlay.SetActive(false);
        weaponCamera.SetActive(true);

        mainCamera.fieldOfView = normalFOV;

    }
    IEnumerator OnScoped()
    {
        yield return new WaitForSeconds(.15f);


        int currentWeapon = WeaponSwitching.selectedWeapon;
        if (currentWeapon == 0)
        {
            animator.SetBool("IsAR", true);
            animator.SetBool("IsScoped", true);
        }
        else if (currentWeapon == 1)
        {
            animator.SetBool("IsRevolver", true);
            animator.SetBool("IsScoped", true);
        }
        else if (currentWeapon == 2)
        {
            animator.SetBool("IsSMG", true);
            animator.SetBool("IsScoped", true);
        }
        else if (currentWeapon == 3)
        {
            animator.SetBool("IsShotgun", true);
            animator.SetBool("IsScoped", true);
        }
        else if (currentWeapon == 4)
        {
            animator.SetBool("IsSniper", true);
            animator.SetBool("IsScoped", true);
            scopeOverlay.SetActive(true);
            weaponCamera.SetActive(false);
        }

        mainCamera.fieldOfView = scopedFOV;

    }



}
