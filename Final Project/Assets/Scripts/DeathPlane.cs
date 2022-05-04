using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public PlayerDeath playerDeath;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerDeath.GameOver();
        }
    }
}
