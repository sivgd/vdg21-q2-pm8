using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditRoller : MonoBehaviour
{
    private static int nScreens = 7;
    private GameObject[] creditScreens = new GameObject[nScreens];
    private static int swapCount = 0;


    // Use this for initialization
    void Start()
    {
        //For each credit screen, add a new reference here:
        creditScreens[0] = GameObject.Find("Credit1");
        creditScreens[1] = GameObject.Find("Credit2");
        creditScreens[2] = GameObject.Find("Credit3");
        creditScreens[3] = GameObject.Find("Credit4");
        creditScreens[4] = GameObject.Find("Credit5");
        creditScreens[5] = GameObject.Find("Credit6");
        creditScreens[6] = GameObject.Find("Credit7");
        //creditScreens[3] = GameObject.Find("Credit4");
        //creditScreens[4] = GameObject.Find("Credit5");


        //Turn them all off...
        for (int i = 0; i < nScreens; i++)
        {
            creditScreens[i].SetActive(false);
        }
        //Except, turn back on element 0
        creditScreens[0].SetActive(true);
    } //Start


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {
            //Toggle
            int currentScene = swapCount % nScreens;
            creditScreens[currentScene].SetActive(false);
            swapCount++;
            currentScene = swapCount % nScreens;
            creditScreens[currentScene].SetActive(true);


        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            SceneManager.LoadScene("MainMenu"); //Requires "Using" (see above)

        }



    } ////Update

}


