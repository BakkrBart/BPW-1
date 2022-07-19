using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject PauseScreen;
    public GameObject IngameUI;

    bool isPaused = false;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGame();
        }
    }

    public void pauseGame()
    {
        if (isPaused)
        {
            PauseScreen.gameObject.SetActive(false);
            IngameUI.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
            isPaused = false;
        } else
        {
            PauseScreen.gameObject.SetActive(true);
            IngameUI.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            isPaused = true;
        }
    }
}
