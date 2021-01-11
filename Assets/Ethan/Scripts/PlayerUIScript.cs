using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerUIScript : MonoBehaviour
{

    public int PlayermaxHealth = 100;
    public int PlayercurrentHealth;


    public HealthBarScript healthBar;
    public LifeCounterScript LifeCounter;


    // Sets the current player health to the max health
    void Start()
    {
        PlayercurrentHealth = PlayermaxHealth;
        healthBar.SetMaxHealth(PlayermaxHealth);
    }

    // Test health for the player
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerTakeDamage(20);
        }
    }

    // The code for making the player take damage 
    public void PlayerTakeDamage(int damage)
    {
        PlayercurrentHealth -= damage;
        healthBar.SetHealth(PlayercurrentHealth);
        PlayercheckDead();
    }

    // The code for checking if the player is dead
    void PlayercheckDead()
    {
        if (PlayercurrentHealth <= 0)
        {
           LifeCounter.TakeLife();
           if (LifeCounter.lifeCounter <= -1)
           {
               // SceneManager.LoadScene("");
                Destroy(gameObject);
           }
           PlayercurrentHealth = PlayermaxHealth;
           healthBar.SetHealth(PlayercurrentHealth);

            if (PlayercurrentHealth >= 100)
               PlayercurrentHealth = PlayermaxHealth;

            if (LifeCounter.lifeCounter >= 6)
                LifeCounter.lifeCounter = LifeCounter.startingLives;
        }
            
    }

}
