using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestPlayerUIScript : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;


    public HealthBarScript healthBar;
    public LifeCounterScript LifeCounter;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        checkDead();
    }

    void checkDead()
    {
        if (currentHealth == 0)
        {
           LifeCounter.TakeLife();
           currentHealth = maxHealth;
           healthBar.SetHealth(currentHealth);
        }
            
    }
}
