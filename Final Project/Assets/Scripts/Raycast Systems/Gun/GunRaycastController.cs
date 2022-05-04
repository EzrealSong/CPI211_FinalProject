using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRaycastController : MonoBehaviour
{
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private GameObject UI1;
    [SerializeField] private GameObject UI2;
    [SerializeField] private GameObject UI3;
    [SerializeField] private GameObject UI4;
    [SerializeField] private GameObject UI5;

    public void ReceiveGun(string name)
    {

        if (name == "OutsideAR")
        {

            inventory.GunCollected(1);
            UI1.SetActive(true);
        }
        else if (name == "OutsideRevolver")
        {
            inventory.GunCollected(2);
            UI2.SetActive(true);
        }
        else if (name == "OutsideSMG")
        {
            inventory.GunCollected(3);
            UI3.SetActive(true);
        }
        else if (name == "OutsideShotgun")
        {
            inventory.GunCollected(4);
            UI4.SetActive(true);
        }
        else if (name == "OutsideSniper")
        {
            inventory.GunCollected(5);
            UI5.SetActive(true);
        }
        FindObjectOfType<AudioManager>().Play("Pick Up");
        gameObject.SetActive(false);

    }
}
