using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backdoor : MonoBehaviour
{
    public Transform game_manager;
    public Transform spawn;

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals(TagManager.sc_virus_tag))
        {
            game_manager.GetComponent<SpawnerManager>().spawn = spawn;
            Destroy(gameObject);
        }
    }
}
