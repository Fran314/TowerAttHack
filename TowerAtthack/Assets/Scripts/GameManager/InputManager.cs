using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pause_panel;

    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!pause_panel.activeInHierarchy)
            {
                pause();
            }
            else
            {
                unpause();
            }
        }
        if (!pause_panel.activeInHierarchy)
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                Time.timeScale = 3;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }

    public void pause()
    {
        Time.timeScale = 0;
        pause_panel.SetActive(true);
    }

    public void unpause()
    {
        Time.timeScale = 1;
        pause_panel.SetActive(false);
    }
}
