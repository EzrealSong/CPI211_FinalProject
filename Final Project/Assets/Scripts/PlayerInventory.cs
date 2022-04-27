using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private Text lootCount;
    [SerializeField] private Text keyCount;

    public int AmountOfLoot { get; private set; }
    public int AmountOfKeys { get; private set; }

    public bool hasAR = false;
    public bool hasRevolver = false;
    public bool hasSMG = false;
    public bool hasShotgun = false;
    public bool hasSniper = false;



    public void LootCollected(int amount)
    {
        AmountOfLoot = AmountOfLoot + amount;
        lootCount.text = (("Loot: ")+(AmountOfLoot.ToString())  );
    }

    public void KeyCollected()
    {
        AmountOfKeys++;
        keyCount.text = (("Keys: ") + (AmountOfKeys.ToString()));

        FindObjectOfType<AudioManager>().Play("Key Sound");

    }

    public void TakeAwayKey()
    {
        AmountOfKeys--;
        keyCount.text = (("Keys: ") + (AmountOfKeys.ToString()));
    }
    public void GunCollected(int gunType)
    {
        if(gunType == 1)
        {
            hasAR = true;
        } else if(gunType == 2)
        {
            hasRevolver = true;
        } else if(gunType == 3)
        {
            hasSMG = true;
        } else if(gunType == 4)
        {
            hasShotgun = true;
        } else if(gunType == 5)
        {
            hasSniper = true;
        }
    }
}
