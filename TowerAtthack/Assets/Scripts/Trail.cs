using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    public Transform target;
    public float speed = 1f;
    public float threshold = 0.1f;

    void Start()
    {
        
    }
    
    void Update()
    {
        Vector3 move = target.position - transform.position;
        transform.Translate(move.normalized * speed * Time.deltaTime);

        if(Vector3.Distance(target.position, transform.position) <= threshold)
        {
            Destroy(gameObject);
        }
    }
}
