using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    public float speed = 10f;
    public float life_span = 5f;

    private Transform target;

    void Start()
    {
        
    }

    public void setTarget(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        life_span -= Time.deltaTime;
        if (life_span <= 0)
        {
            Destroy(gameObject);
            return;
        }
        if (target != null)
        {
            Vector3 dir = target.position - transform.position;
            float next_distance = speed * Time.deltaTime;

            if(dir.magnitude <= next_distance)
            {
                Debug.Log("Hit!");
                Destroy(gameObject);
            }
            else
            {
                transform.Translate(dir.normalized * next_distance, Space.World);
            }
        }
    }
}
