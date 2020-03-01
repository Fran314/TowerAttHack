using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public Transform spawn;
    public Object basic_virus_prefab;
    public Object sc_virus_prefab;

    void Start()
    {
        InvokeRepeating("SpawnBasic", 1f, 5f);
        InvokeRepeating("SpawnSC", 13f, 10f);
    }

    public void SpawnBasic()
    {
        GameObject virus = (GameObject) Instantiate(basic_virus_prefab, spawn.position, Quaternion.identity);
        virus.GetComponent<Virus>().setTarget(spawn.GetComponent<Spawn>().first_target);
        VirusListManager.viruses.Add(virus);
    }

    public void SpawnSC()
    {
        GameObject virus = (GameObject)Instantiate(sc_virus_prefab, spawn.position, Quaternion.identity);
        virus.GetComponent<Virus>().setTarget(spawn.GetComponent<Spawn>().first_target);
        VirusListManager.viruses.Add(virus);
    }

    void Update()
    {
        //Debug.Log(VirusListManager.viruses.Count + " ");
    }
}
