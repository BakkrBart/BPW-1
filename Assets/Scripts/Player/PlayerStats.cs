using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : CharacterStats
{
    public PlayerController movement;
    void Start()
    {
        maxHealth = 100;
        currHealth = maxHealth;
        GetComponent<PlayerController>().enabled = true;
    }

    private void Update()
    {
        CheckHealth();
    }

    public override void Die()
    {
        GetComponent<PlayerController>().enabled = false;
        GetComponent<PlayerUI>().YouDied();
        Cursor.lockState = CursorLockMode.None;
    }
}
