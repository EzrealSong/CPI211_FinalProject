using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    [Header("Volume Setting")]
    [SerializeField] private Text volumeTextValue = null;
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private int defaultVolume = 10;
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

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        volumeTextValue.text = volume.ToString("0");
    }

    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        
    }

    public void ResetButton(string MenuType)
    {
        if(MenuType == "Audio")
        {
            AudioListener.volume = defaultVolume;
            volumeSlider.value = defaultVolume;
            volumeTextValue.text = defaultVolume.ToString("0");
            VolumeApply();
        }
    }

    

}
