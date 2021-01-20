using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsanityBarScript : MonoBehaviour
{
    public PlayerUIScript PlayerUI;
    public HealthBarScript healthbar;
    public GameObject insanity1;
    public GameObject insanity2;
    public GameObject insanity3;
    public GameObject Enemy;
    public Insanity insanity;
    private Image barImage;

    // Updates the fill for the insanity bar
    private void Awake()
    {
        barImage = transform.Find("Fill").GetComponent<Image>();
        
        insanity = new Insanity();
    }

    // Makes the insanity bar deal damage to the Player and updates the insanity bar
    private void Update()
    {
        insanity.update();

        barImage.fillAmount = insanity.GetInsanityNormalized();

        
        if (insanity.GetInsanityNormalized() == 1)
        {
             PlayerUI.PlayerTakeDamage(20);
             insanity.insanityReset();
            Instantiate(Enemy, insanity1.transform.position, insanity1.transform.rotation);
            Instantiate(Enemy, insanity2.transform.position, insanity2.transform.rotation);
            Instantiate(Enemy, insanity3.transform.position, insanity3.transform.rotation);
        }

    }
}

public class Insanity {

    public const int INSANITY_MAX = 100;

    public float insanityAmount;
    private float insanityRegenAmount;
    
    // Sets the insanity amount
     public Insanity()
    {
        insanityAmount = 0;
        insanityRegenAmount = 2f;
    }

    // Resets the insanity amount
    public void insanityReset()
    {
        insanityAmount = 0;
        //insanityRegenAmount = 10f;
    }

    // Uh cant actually remember what this does but its importent 
    public void update()
    {
        insanityAmount += insanityRegenAmount * Time.deltaTime;
        insanityAmount = Mathf.Clamp(insanityAmount, 0f, INSANITY_MAX);
    }

    // Not sure if this does anything
    public void TrySpendingInsanity(int amount)
    {
        if (insanityAmount >= amount)
        {
            insanityAmount -= amount;
        }
    } 

    // Gets the normalized insanity amount
    public float GetInsanityNormalized()
    {
        return insanityAmount / INSANITY_MAX;
    }    
} 

