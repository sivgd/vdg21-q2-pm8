using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsanityBarScript : MonoBehaviour
{
    private Insanity insanity;
    private Image barImage;


    private void Awake()
    {
        barImage = transform.Find("Fill").GetComponent<Image>();
        
        insanity = new Insanity();
    }

    private void Update()
    {
        insanity.update();

        barImage.fillAmount = insanity.GetInsanityNormalized();
    }
}

public class Insanity {

    public const int INSANITY_MAX = 100;

    private float insanityAmount;
    private float insanityRegenAmount;

    public Insanity( )
    {
        insanityAmount = 0;
        insanityRegenAmount = .2f;
    }

    public void update()
    {
        insanityAmount += insanityRegenAmount * Time.deltaTime;
        insanityAmount = Mathf.Clamp(insanityAmount, 0f, INSANITY_MAX);
    }

    public void TrySpendingInsanity(int amount)
    {
        if (insanityAmount >= amount)
        {
            insanityAmount -= amount;
        }
    }

    public float GetInsanityNormalized()
    {
        return insanityAmount / INSANITY_MAX;
    }
} 

