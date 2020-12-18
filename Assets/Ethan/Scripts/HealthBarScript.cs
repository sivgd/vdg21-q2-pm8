using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;

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

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1);
    }

    public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }       
}
