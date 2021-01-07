using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsanityBarScript : MonoBehaviour
{
    public PlayerUIScript PlayerUI;
    public HealthBarScript healthbar;

    private Insanity insanity;
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

        //public float test =
        //Debug.Log(insanity.GetInsanityNormalized());
        if (insanity.GetInsanityNormalized() == 1)
        {
            PlayerUI.PlayerTakeDamage(20);
            insanity.insanityReset();
        }

    }
}

public class Insanity {

    public const int INSANITY_MAX = 100;

    private float insanityAmount;
    private float insanityRegenAmount;
    
    // Sets the insanity amount
     public Insanity()
    {
        insanityAmount = 0;
        insanityRegenAmount = 10f;
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

    // might need this for later
    /*public void TakeInsanityDamage()
     {

     } */

    
} 

