using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public float damageTime;
    private float damageTimeCounter;
    public bool noDamage;


    public UnityEvent<Transform> onTakeDamage;
    public UnityEvent OnDie;

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
            onTakeDamage?.Invoke(attacker.transform);
        }
        else
        {
            currentHealth = 0;
            OnDie?.Invoke();
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