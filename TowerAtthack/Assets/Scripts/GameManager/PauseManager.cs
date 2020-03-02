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
            Time.timeScale = 1 - Time.timeScale;
            pause_panel.SetActive(!pause_panel.activeInHierarchy);
        }
    }
}
