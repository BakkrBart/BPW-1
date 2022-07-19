using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public float currHealth;
    public float maxHealth;

    public float damage;

    public bool isDead = false;

    public void CheckHealth()
    {
        if (currHealth >= maxHealth)
        {
            currHealth = maxHealth;
        }

        if (currHealth <= 0)
        {
            currHealth = 0;
            isDead = true;
        }
        if (isDead == true)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        //Override
    }

    public void TakeDamage(float damage)
    {
        currHealth -= damage;
    }
}
