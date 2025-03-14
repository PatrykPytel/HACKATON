using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausemenu : MonoBehaviour
{
    public GameObject PauseMenu;
    public bool isPaused;
    
    void Start()
    {
        PauseMenu.SetActive(false);
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                pauseMenu();
            }
        }
    }
    public void pauseMenu()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
}
