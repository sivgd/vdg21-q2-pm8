using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsanityBarScript : MonoBehaviour
{

    public TestPlayerUIScript TestPlayer;
    public HealthBarScript healthbar;

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

        //public float test =
        //Debug.Log(insanity.GetInsanityNormalized());
        if (insanity.GetInsanityNormalized() == 1)
        {
            TestPlayer.TakeDamage(20);
            insanity.insanityReset();
        }

    }
}

public class Insanity {

    public const int INSANITY_MAX = 100;

    private float insanityAmount;
    private float insanityRegenAmount;

     public Insanity()
    {
        insanityAmount = 0;
        insanityRegenAmount = 10f;
    }

    public void insanityReset()
    {
        insanityAmount = 0;
        //insanityRegenAmount = 10f;
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

    public void TakeInsanityDamage()
    {

    }

} 

