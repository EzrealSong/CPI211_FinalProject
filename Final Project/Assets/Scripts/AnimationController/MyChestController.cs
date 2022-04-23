using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyChestController : MonoBehaviour
{
    private Animator chestAnim;

    private bool chestOpen = false;

    private void Awake()
    {
        chestAnim = gameObject.GetComponent<Animator>();
    }


    public void PlayAnimation()
    {
        if (!chestOpen)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            chestAnim.SetBool("IsOpened", true);
            //chestAnim.Play("ChestOpen", 0, 0.0f);
            chestOpen = true;
        }
        
    }
}
