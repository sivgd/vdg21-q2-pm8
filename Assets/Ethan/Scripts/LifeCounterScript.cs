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

    // Start is called before the first frame update
    void Start()
    {
        theText = GetComponent<Text>();

        lifeCounter = startingLives;
    }

    // Update is called once per frame
    void Update()
    {
        theText.text = "x " + lifeCounter;
       /* if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeLife();
        }*/
    }

    public void GiveLife()
    {
        lifeCounter++;
    }

    public void TakeLife()
    {
        lifeCounter--;
    }

    
}
