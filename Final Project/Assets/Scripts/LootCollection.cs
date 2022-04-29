using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootCollection : MonoBehaviour
{
    [SerializeField] private int lootAmount;

    private PlayerInventory inventory;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            inventory = other.GetComponent<PlayerInventory>();

        if (inventory != null)
        {
            if (gameObject.tag == "Loot")
            {


                inventory.LootCollected(lootAmount);
                gameObject.SetActive(false);
            }
            else if (gameObject.tag == "Key")
            {
                inventory.KeyCollected();
                gameObject.SetActive(false);
            }
        }

    }
}
