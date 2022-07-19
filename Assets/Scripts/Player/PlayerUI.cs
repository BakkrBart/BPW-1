using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Text healthAmount;

    public GameObject DeathScreen;
    public GameObject IngameUI;

    CharacterStats playerStats;
    private void Start()
    { 
        playerStats = GetComponent<CharacterStats>();
        SetStats();
    }

    private void Update()
    {
        SetStats();
    }

    void SetStats()
    {
        if (playerStats.currHealth <= 20)
        {
            healthAmount.color = Color.red;
        }
        else
        {
            healthAmount.color = Color.green;
        }
        healthAmount.text = playerStats.currHealth.ToString();
    }

    public void YouDied()
    {
        DeathScreen.gameObject.SetActive(true);
        IngameUI.gameObject.SetActive(false);
    }

    void PauseGame()
    {
        //PauseScreen.gameObject.SetActive(true);
        //IngameUI.gameObject.SetActive(false);
        //Paused = true;
    }
    void ResumeGame()
    {
        //PauseScreen.gameObject.SetActive(false);
        //IngameUI.gameObject.SetActive(true);
        //Paused = false;
    }
}