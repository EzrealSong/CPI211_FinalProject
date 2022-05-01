using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDoorController : MonoBehaviour
{
    [SerializeField] private Animator doorAnim;

    private bool doorOpen = false;

    private void Awake()
    {
        doorAnim = gameObject.GetComponent<Animator>();
    }


    public void PlayAnimation()
    {
        if (!doorOpen)
        {
            FindObjectOfType<AudioManager>().Play("Door Open");
            doorAnim.Play("DoorOpen", 0, 0.0f);
            doorOpen = true;
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("Door Close");
            doorAnim.Play("DoorClose", 0, 0.0f);
            doorOpen = false;
        }
    }
}
