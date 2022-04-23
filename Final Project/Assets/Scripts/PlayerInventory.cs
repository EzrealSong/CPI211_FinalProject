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



    public void LootCollected()
    {
        AmountOfLoot++;
        lootCount.text = (("Loot: ")+(AmountOfLoot.ToString())  );
    }

    public void KeyCollected()
    {
        AmountOfKeys++;
        keyCount.text = (("Keys: ") + (AmountOfKeys.ToString()));
    }

    public void TakeAwayKey()
    {
        AmountOfKeys--;
        keyCount.text = (("Keys: ") + (AmountOfKeys.ToString()));
    }
}
