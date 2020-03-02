using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backdoor : MonoBehaviour
{
    public Transform game_manager;
    public Transform spawn;
    public GameObject particle_prefab;

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals(TagManager.bd_virus_tag))
        {
            game_manager.GetComponent<SpawnerManager>().spawn = spawn;
            Instantiate(particle_prefab, spawn.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
