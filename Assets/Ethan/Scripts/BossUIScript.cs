using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossUIScript : MonoBehaviour
{
    public int BossmaxHealth = 250;
    public int BosscurrentHealth;
    public PlayerUIScript player;
    //public HealthBarScript healthofplayer;

    

    // Sets the bosses current health
    void Start()
    {
        BosscurrentHealth = BossmaxHealth;
    }

    // Test health for boss
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            BossTakeDamage(25);
        }                           
    }

    //  makes the boss do damage to the player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "TestPlayer")
            player.PlayerTakeDamage(25);
    }

    // makes the boss take damage
    public void BossTakeDamage(int damage)
    {
        BosscurrentHealth -= damage;
        BosscheckDead();
    }

    // Checks if the boss is dead
    void BosscheckDead()
    {
        if (BosscurrentHealth == 0)
        {
            Destroy(gameObject);
        }
    }    
}
