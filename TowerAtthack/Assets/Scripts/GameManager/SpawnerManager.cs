using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public Transform spawn;

    private AwarenessManager aw_manager;

    void Start()
    {
        aw_manager = gameObject.GetComponent<AwarenessManager>();
    }

    public void Spawn(Object virus_prefab)
    {
        GameObject virus = (GameObject)Instantiate(virus_prefab, spawn.position, Quaternion.identity);
        Virus virus_script = virus.GetComponent<Virus>();
        virus_script.setTarget(spawn.GetComponent<Spawn>().first_target);
        aw_manager.awareness += virus_script.awareness_increment;
    }

    void Update()
    {

    }
}
