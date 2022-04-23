using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItemController : MonoBehaviour
{
    [SerializeField] private bool door = false;
    [SerializeField] private bool key = false;
    [SerializeField] private bool chest = false;

    [SerializeField] private PlayerInventory inventory;

    private KeyDoorController doorObject;

    private void Start()
    {
      if (door)
      {
            doorObject = GetComponent<KeyDoorController>();
       }
    }

    public void ObjectInteraction()
    {
        if (door)
        {
            doorObject.PlayAnimation();
        } else if (key)
        {
            inventory.KeyCollected();
            gameObject.SetActive(false);
        }
       
    }
}
