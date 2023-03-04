using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript 
{
    
    public float maxHealth;
    public float currentHealth;
    Image image;
    
    public void Initialize(float max,Image _image)
    {
        maxHealth = max;
        currentHealth = maxHealth;
        image = _image; 
        UpdateUI();
    }
    public void Spanked(float hitValue)
    {
        currentHealth -= hitValue;
        UpdateUI() ;
    }

    public void ChangeMaxHealth(float max)
    {
        maxHealth = max;
        UpdateUI () ;

    }

    public void Heal(float healValue)
    {
        currentHealth += healValue;
        UpdateUI ();
    }

    public void UpdateUI()
    {
        float weightedHealth = currentHealth / maxHealth;
        Debug.Log(weightedHealth);
        image.fillAmount = weightedHealth;

    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }
}
