using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUIScript : MonoBehaviour
{
    public int EnemymaxHealth = 50;
    public int EnemycurrentHealth;

    public PlayerUIScript Player;
    public HealthBarScript playerhealth;


    // Sets the enemy's current health
    void Start()
    {
        EnemycurrentHealth = EnemymaxHealth;
        
    }

    // Test for enemy health
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            EnemyTakeDamage(25);
        }
    }

    // Makes the enemy deal damage to the player
   /* private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            Player.PlayerTakeDamage(10);
    } */

    // Makes the enemy deal damage to the player
    public void EnemyTakeDamage(int damage)
    {
        EnemycurrentHealth -= damage;
        EnemycheckDead();

    }

    // Checks if the enemy is dead
    void EnemycheckDead()
    {
        if (EnemycurrentHealth == 0)
        {          
            Destroy(gameObject);
        }

    }

    // extra
  private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "TestPlayer")
            Player.PlayerTakeDamage(10);
    } 
}