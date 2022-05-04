using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Summary : MonoBehaviour
{
    [SerializeField]
    private Text LootShow;
    [SerializeField]
 
    public int loot { get; private set; }
    [SerializeField]
    public PlayerInventory inventory;
    
    Player player;

    void start()
    {

    }
    // public void summaryLoot()
    // {
    //     loot += inventory.AmountOfLoot;
    //     Setup(loot);
    // }

    // public void Setup(int num)
    // {
    //     LootShow.text = num.ToString("");
    // }

    // void Start()
    // {
    //     starttime = Time.time;
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     if (player.gameover == true)
    //     {
    //         float t = Time.time - starttime;

    //         string minutes = ((int)t / 60).ToString();
    //         string seconds = (t % 60).ToString("f2");

    //         TimeResult.text = minutes + ":" + seconds;
    //     }
    //     else
    //     {
    //         Finnish();
    //     }
    // }


    // public void Finnish()
    // {
    //     TimeResult.color = Color.yellow;
    // }
    }
