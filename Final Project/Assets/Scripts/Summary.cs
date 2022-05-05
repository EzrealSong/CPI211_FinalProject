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
    [SerializeField] public FirstPersonLook firstPersonLook;
    [SerializeField] public GunSystem gunSystem1;
    [SerializeField] public GunSystem gunSystem2;
    [SerializeField] public GunSystem gunSystem3;
    [SerializeField] public GunSystem gunSystem4;
    [SerializeField] public GunSystem gunSystem5;
    [SerializeField] public Jump jump;
    [SerializeField] public WeaponSwitching weaponSwitching;
    [SerializeField] public Zoom zoom;
    [SerializeField] public Crouch crouch;
    



    Player player;
    PlayerInventory playerinven;

    void Start()
    {
        move.canMove = false;
        firstPersonLook.canLook = false;
        gunSystem1.canFire = false;
        gunSystem2.canFire = false;
        gunSystem3.canFire = false;
        gunSystem4.canFire = false;
        gunSystem5.canFire = false;
        jump.canJump = false;
        weaponSwitching.canSwitch = false;
        zoom.canZoom = false;
        crouch.canCrouch = false;
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
