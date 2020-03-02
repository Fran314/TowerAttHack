using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AwarenessManager : MonoBehaviour
{
    public float awareness = 0f;
    public float color = 0;

    public Image awareness_bar;
    public Image antivirus_update;

    public Transform buttons_folder;
    private Button[] buttons;

    private int blink_counter = 0;
    private int blink_amount = 2;
    private float blink_time = 0.5f;

    void Start()
    {
        buttons = new Button[buttons_folder.childCount];
        for (int i = 0; i < buttons_folder.childCount; i++)
            buttons[i] = buttons_folder.GetChild(i).GetComponent<Button>();

        antivirus_update.color = new Color(antivirus_update.color.r, antivirus_update.color.g, antivirus_update.color.b, 0);
    }
    
    void Update()
    {
        awareness -= Time.deltaTime * gameObject.GetComponent<SpawnerManager>().spawn.GetComponent<Spawn>().awareness_decrease_multiplier;
        if (awareness < 0) awareness = 0;

        awareness_bar.fillAmount = awareness / (100f);
        color = 149 - (awareness * (149f / 100f));
        awareness_bar.color = new Color(219f / 255f, (149 - (awareness * (149f / 100f))) / 255f, 0f);

        if(awareness >= 100)
        {
            Invoke("doTheBlink", 0f);
            awareness = 0;
            int to_disable = Random.Range(0, buttons.Length);

            buttons[to_disable].enabled = false;
            buttons[to_disable].GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f);
        }
    }

    void doTheBlink()
    {
        blink_counter++;
        if(blink_counter%2 == 0)
        {
            antivirus_update.color = new Color(antivirus_update.color.r, antivirus_update.color.g, antivirus_update.color.b, 0);
        }
        else
        {
            antivirus_update.color = new Color(antivirus_update.color.r, antivirus_update.color.g, antivirus_update.color.b, 1);
        }

        if (blink_counter < blink_amount*2) Invoke("doTheBlink", blink_time);
        else blink_counter = 0;
    }
}
