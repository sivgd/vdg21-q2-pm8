using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCounterScript : MonoBehaviour
{

    public int startingLives = 5;
    public int lifeCounter; 

    public Text theText;
    //private HealthBarScript healthCounter;

    // Gets the lives amount for the life counter
    void Start()
    {
        theText = GetComponent<Text>();

        lifeCounter = startingLives;
    }

    // Updates the life counter amount
    void Update()
    {
        theText.text = "x " + lifeCounter;
       /* if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeLife();
        }*/
    }

    // Adds extra lives
    public void GiveLife()
    {
        lifeCounter++;
    }

    // Takes away lives
    public void TakeLife()
    {
        lifeCounter--;
    }

    
}
