using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField]
   private Text LootResult;
    void start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
  
   public void Setup(int loot)//show loot value in death screen
    {
        gameObject.SetActive(true);
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
