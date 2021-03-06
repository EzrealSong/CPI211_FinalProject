
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{

    public Animator animator;
    public static int selectedWeapon = 0;
    public bool canSwitch = true;

    [SerializeField] private PlayerInventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        //SelectWeapon();
        //animator.SetBool("IsAR", true);
    }

    // Update is called once per frame
    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;

        /*if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= transform.childCount - 1)
            {
                selectedWeapon = 0;
            }
            else
            {
                selectedWeapon++;
            }

        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0)
            {
                selectedWeapon = transform.childCount-1;
            }
            else
            {
                selectedWeapon--;
            }

        }*/
        if (canSwitch)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (inventory.hasAR)
                {
                    selectedWeapon = 0;
                    animator.SetBool("IsAR", true);
                    animator.SetBool("IsRevolver", false);
                    animator.SetBool("IsSMG", false);
                    animator.SetBool("IsShotgun", false);
                    animator.SetBool("IsSniper", false);
                    SelectWeapon();
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
            {
                if (inventory.hasRevolver)
                {
                    selectedWeapon = 1;
                    animator.SetBool("IsAR", false);
                    animator.SetBool("IsRevolver", true);
                    animator.SetBool("IsSMG", false);
                    animator.SetBool("IsShotgun", false);
                    animator.SetBool("IsSniper", false);
                    SelectWeapon();
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
            {
                if (inventory.hasSMG)
                {
                    selectedWeapon = 2;
                    animator.SetBool("IsAR", false);
                    animator.SetBool("IsRevolver", false);
                    animator.SetBool("IsSMG", true);
                    animator.SetBool("IsShotgun", false);
                    animator.SetBool("IsSniper", false);
                    SelectWeapon();
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
            {
                if (inventory.hasShotgun)
                {
                    selectedWeapon = 3;
                    animator.SetBool("IsAR", false);
                    animator.SetBool("IsRevolver", false);
                    animator.SetBool("IsSMG", false);
                    animator.SetBool("IsShotgun", true);
                    animator.SetBool("IsSniper", false);
                    SelectWeapon();
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha5) && transform.childCount >= 5)
            {
                if (inventory.hasSniper)
                {
                    selectedWeapon = 4;
                    animator.SetBool("IsAR", false);
                    animator.SetBool("IsRevolver", false);
                    animator.SetBool("IsSMG", false);
                    animator.SetBool("IsShotgun", false);
                    animator.SetBool("IsSniper", true);
                    SelectWeapon();
                }
            }
            if (previousSelectedWeapon != selectedWeapon)
            {
                SelectWeapon();
            }

        }
    }
    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
