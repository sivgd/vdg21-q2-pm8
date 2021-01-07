using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButtonForMenu : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit");
    }
}
