using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessorManager : MonoBehaviour
{
    void Start()
    {
        
    }
    
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (Util.getTagType(col.gameObject.tag).Equals(TagManager.virus_tag))
        {
            GetComponentInParent<HealthManager>().life -= col.gameObject.GetComponent<Virus>().damage_output;

            Destroy(col.gameObject);
        }
    }
}
