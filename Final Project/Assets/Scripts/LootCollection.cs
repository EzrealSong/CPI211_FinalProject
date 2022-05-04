using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootCollection : MonoBehaviour
{
    [SerializeField] private int lootAmount;

    private PlayerInventory inventory;
    [SerializeField] public Player player;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            inventory = other.GetComponent<PlayerInventory>();

        if (inventory != null)
        {
            if (gameObject.tag == "Loot")
            {

                FindObjectOfType<AudioManager>().Play("Gold Pickup");
                inventory.LootCollected(lootAmount);
                gameObject.SetActive(false);
            }
            else if (gameObject.tag == "Key")
            {
                inventory.KeyCollected();
                gameObject.SetActive(false);
            } else if(gameObject.tag == "Gem")
            {
                FindObjectOfType<AudioManager>().Play("Key Sound");
                inventory.LootCollected(lootAmount);
                gameObject.SetActive(false);
                player.HealDiamonds();
            }
            else if (gameObject.tag == "ChestLoot")
            {
                FindObjectOfType<AudioManager>().Play("Chest Gold");
                inventory.LootCollected(lootAmount);
                gameObject.SetActive(false);
            }
        }

    }
}
