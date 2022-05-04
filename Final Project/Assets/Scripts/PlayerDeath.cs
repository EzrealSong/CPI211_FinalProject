using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField]
    private Text LootShow;
    [SerializeField]
    private Text SummaryLoot;
    public int LootsResult { get; private set; }
    public Player PlayerHealth;
    public PlayerInventory inventory;
    public GameObject Player;
    [SerializeField] private FirstPersonMovement move;

    public void GameOver()
    {
        Debug.Log("AAAAAHHHH");
        LootsResult += inventory.AmountOfLoot;
        Setup(LootsResult);
    }
    public void Setup(int loot)//show loot value in death screen
    {
        move.canMove = false;
        //Destroy(Player.gameObject.GetComponent<FirstPersonMovement>());
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        this.gameObject.SetActive(true);
        //LootShow.text = "You have lost " + loot.ToString() + " Value Loots";
        SummaryLoot.text = loot.ToString();
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
