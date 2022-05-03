using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField]
    private Text LootResult;
    public int LootsResult { get; private set; }
    public Player PlayerHealth;
    public PlayerInventory inventory;
    public GameObject Player;

    public void GameOver()
    {
        LootsResult += inventory.AmountOfLoot;
        Setup(LootsResult);
    }
    public void Setup(int loot)//show loot value in death screen
    {
        Destroy(Player.gameObject.GetComponent<FirstPersonMovement>());
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        this.gameObject.SetActive(true);
        LootResult.text = "You have lost " + loot.ToString() + " Value Loots";
    }

    public void Restart()
    {
        SceneManager.LoadScene("Final Project");
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
