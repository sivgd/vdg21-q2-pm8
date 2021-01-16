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
    public InsanityBarScript insanityhurt;


    // Sets the current player health to the max health
    void Start()
    {
        PlayercurrentHealth = PlayermaxHealth;
        healthBar.SetMaxHealth(PlayermaxHealth);
    }

    // Test health for the player
    void Update()
    {
       // if (Input.GetKeyDown(KeyCode.Space))
        {
       //     PlayerTakeDamage(20);
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
           if (PlayerPrefs.GetInt("Lives") <= -1)
           {
                SceneManager.LoadScene("DeathScreen");
                Destroy(gameObject);
           }
           PlayercurrentHealth = PlayermaxHealth;
           healthBar.SetHealth(PlayercurrentHealth);
        }
            
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            insanityhurt.insanity.insanityAmount += 5;
            PlayerTakeDamage(10);
        }  

        if (collision.gameObject.tag == "Boss")
        {
            insanityhurt.insanity.insanityAmount += 25;
            PlayerTakeDamage(25);
            //Debug.Log("boss take damage");
            //Debug.Log(collision.gameObject.tag);
        }
    }
}