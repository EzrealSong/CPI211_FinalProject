using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

   [SerializeField] public Animator mainMenuAnim;
    //Play Game
    public void PlayGame()
    {
        MusicChange();
        SceneManager.LoadScene("Final Project");
    }

    //Quit game
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    IEnumerator MusicChange()
    {
        mainMenuAnim.SetBool("IsFadeOut", true);
        yield return new WaitForSeconds(5);
    }
}
