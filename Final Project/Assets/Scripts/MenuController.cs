using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    //Play Game
    public void PlayGame()
    {
        SceneManager.LoadScene("Final Project");
    }

    //Quit game
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
