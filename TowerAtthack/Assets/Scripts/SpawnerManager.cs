using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public Transform spawn;
    public Object virus_prefab;

    void Start()
    {
        InvokeRepeating("Spawn", 1f, 5f);
    }

    public void Spawn()
    {
        Instantiate(virus_prefab, spawn);
    }
    
    void Update()
    {
        
    }
}
