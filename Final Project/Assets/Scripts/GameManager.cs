using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerDeath playerdeath;
    public PlayerInventory inventory;

    public int playerHealth = 100;

    [SerializeField]
    public int LootsResult { get; private set; }


    private void Update()
    {
        if (playerHealth <= 0)
            GameOver(inventory.AmountOfLoot);
    }

    public void GameOver(int amount)
    {
        LootsResult += amount;
        playerdeath.Setup(LootsResult);
    }
}
