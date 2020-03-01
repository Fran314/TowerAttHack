using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusListManager : MonoBehaviour
{
    public static GameObject[] getVirusesArray()
    {
        List<GameObject> viruses_list = new List<GameObject>();
        viruses_list.AddRange(GameObject.FindGameObjectsWithTag(TagManager.basic_virus_tag));
        viruses_list.AddRange(GameObject.FindGameObjectsWithTag(TagManager.sc_virus_tag));

        return viruses_list.ToArray();
    }
}