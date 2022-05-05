using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Summary : MonoBehaviour
{
    [SerializeField] 
    private FirstPersonMovement move;
    [SerializeField]
    private Text LootShow;
    [SerializeField]
    public int loot { get; private set; }
    [SerializeField]
    public PlayerInventory inventory;
    
    [SerializeField]
    public GameObject s;

    [SerializeField]
    public GameObject a;

    [SerializeField]
    public GameObject b;
    [SerializeField]
    public GameObject c;
    [SerializeField]
    public int Loots;


    Player player;
    PlayerInventory playerinven;

    void Start()
    {
        move.canMove = false;
        Loots = playerinven.AmountOfLoot;
    }
    void Update()
    {
        
        if(Loots >= 9000)
        {
            s.SetActive(true);
        }
        else if(Loots < 9000 && Loots >= 7500)
        {
            a.SetActive(true);
        }
        else if(Loots < 7500 && Loots >= 5000)
        {
            b.SetActive(true);
        }
        else
        {
            c.SetActive(true);
        }
    }
   
    }
