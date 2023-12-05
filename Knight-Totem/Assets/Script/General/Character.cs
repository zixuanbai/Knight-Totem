using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public float damageTime;
    private float damageTimeCounter;
    public bool noDamage;

    private void Start()
    {
        currentHealth = maxHealth;
    }
    
    private void Update()
    {
        if (noDamage)
        {
            damageTimeCounter -= Time.deltaTime;
            if (damageTimeCounter <= 0)
            {
                noDamage = false;
            }
        }
    }
    
    
    public void TakeDamage(Attack attacker)
    {
        if (noDamage)
            return;
        if (currentHealth - attacker.damage > 0)
        {
            currentHealth -= attacker.damage;
            TriggerNoDamage();
        }
        else
        {
            currentHealth = 0;
        }
    }

    private void TriggerNoDamage()
    {
        if (!noDamage)
        {
            noDamage = true;
            damageTimeCounter = damageTime;
        }
    }
}
