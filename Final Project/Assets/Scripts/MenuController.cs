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
    
    [Header("Gameplay Settings")]
    [SerializeField] private Text controllerSenTextValue = null;
    [SerializeField] private Slider controllerSenslider = null;
    [SerializeField] private int defaultSen = 4;
    public int mainControllerSen = 4;

    [Header("Toggle Settings")]
    [SerializeField] private Toggle invertYToggle = null;


    [SerializeField] public Animator transition;
    //Play Game
    public void PlayGame()
    {
        MusicChange();
        StartCoroutine(Crossfade());
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

    public void SetControllerSen(float sensitivity)
    {
        mainControllerSen = Mathf.RoundToInt(sensitivity);
        controllerSenTextValue.text = sensitivity.ToString("0");
    }

    public void GameplayApply()
    {
        if(invertYToggle.isOn)
        {
            PlayerPrefs.SetInt("masterInvertY",1);//invert Y
        }
        else
        {
            PlayerPrefs.SetInt("masterInvertY",0);//not Invert
        }
        PlayerPrefs.SetFloat("masterSen",mainControllerSen);
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
        if(MenuType == "Gameplay")
        {
            controllerSenTextValue.text = defaultSen.ToString("0");
            controllerSenslider.value = defaultSen;
            mainControllerSen = defaultSen;
            invertYToggle.isOn = false;
            GameplayApply();
        }
    }

    IEnumerator Crossfade()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(3);
    }

    

}
