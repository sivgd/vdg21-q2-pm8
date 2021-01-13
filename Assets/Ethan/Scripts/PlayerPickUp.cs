using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPickUp : MonoBehaviour
{
    
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "Player")
        {
            PlayerPrefs.SetInt("Lives", 5);
            SceneManager.LoadScene("Main_Enemy");
        }
    }
}
