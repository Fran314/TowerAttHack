using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Firewall : MonoBehaviour
{
    public float health = 100f;
    public Image health_square;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 100f) health_square.enabled = false;
        else
        {
            if(!health_square.isActiveAndEnabled) health_square.enabled = true;
            health_square.fillAmount = health / 100f;
        }
        if(health <= 0f)
        {
            Destroy(gameObject);
            return;
        }
    }
}
