using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    // extra stuff for the life counter
    /*private LifeCounterScript lifesystem;
    
    void Start()
    {
        lifesystem = FindObjectOfType<LifeCounterScript>();
    }

    void Update()
    {
        lifesystem.TakeLife();
    }
    */

    // Sets the max health for the healthbar
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1);
    }

    // Sets the current health for the healthbar
    public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }       
}
