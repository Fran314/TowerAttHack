using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float damage_output = 20f;
    public float life_span = 5f;

    public Transform target;

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
        if (life_span <= 0 || target == null)
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
                //Destroy(target.gameObject);
                target.GetComponent<Virus>().health -= damage_output;
                Destroy(gameObject);
            }
            else
            {
                transform.Translate(dir.normalized * next_distance, Space.World);
            }
        }
    }
}
