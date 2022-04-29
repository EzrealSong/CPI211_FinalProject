using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRaycastController : MonoBehaviour
{
    [SerializeField] private PlayerInventory inventory;

    public void ReceiveGun(string name)
    {

        if (name == "OutsideAR")
        {

            inventory.GunCollected(1);
        }
        else if (name == "OutsideRevolver")
        {
            inventory.GunCollected(2);
        }
        else if (name == "OutsideSMG")
        {
            inventory.GunCollected(3);
        }
        else if (name == "OutsideShotgun")
        {
            inventory.GunCollected(4);
        }
        else if (name == "OutsideSniper")
        {
            inventory.GunCollected(5);
        }

        gameObject.SetActive(false);

    }
}
