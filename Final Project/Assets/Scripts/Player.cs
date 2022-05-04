using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int MaxHealth = 100;
    public int currentHealth;
    public PlayerDeath Playerdeath;
    public Summary summary;
    public HealthBar healthBar;

    public bool gameover = false;

    void Start()
    {
        currentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
    }
    void OnCollisionEnter(Collision colli)
    {
    
        if (colli.gameObject.tag =="Skeleton")
        {
            TakeDamage(25);
            Console.Write("Collided");
        }
        else if (colli.gameObject.tag == "Spider")
        {
            TakeDamage(10);
            Console.Write("Collided");
        }
        else if (colli.gameObject.tag == "Giant")
        {
            TakeDamage(30);
            Console.Write("Collided");
        }
    }
    void TakeDamage(int damage)
        {
            currentHealth -= damage;
            healthBar.setHealth(currentHealth);
            if(currentHealth <= 0)
            {
                gameover = true;
                Playerdeath.GameOver();
                Playerdeath.gameObject.SetActive(true);
            }
            gameover = false;
        
    }
}
