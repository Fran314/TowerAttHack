using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public float life = 1000f;
    public float max_life = 1000f;
    public GameObject success_panel;
    public float healing_speed = 5f;

    public Image life_bar;

    void Start()
    {
        success_panel.SetActive(false);
    }

    void Update()
    {
        if(life <= 0f)
        {
            Time.timeScale = 0;
            success_panel.SetActive(true);
        }

        life += Time.deltaTime * healing_speed;
        if (life >= max_life) life = max_life;

        life_bar.fillAmount = life / max_life;
    }
}
