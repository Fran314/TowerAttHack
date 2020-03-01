using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour
{
    public float speed = 2f;
    public float health = 100f;
    public float max_health = 100f;
    public float damage_output = 20f;

    public Transform target;

    GameObject bug;
    
    void Start()
    {
        //target = TPoints.points[0];
    }

    public void setTarget(Transform _target)
    {
        target = _target;
    }
    
    void Update()
    {
        if(health <= 0f)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 difference = target.position - transform.position;
        Vector3 move = difference.normalized * speed * Time.deltaTime;
        if (move.magnitude < difference.magnitude)
        {
            transform.Translate(move, Space.World);
        }
        else
        {
            transform.Translate(difference, Space.World);
            target = target.GetComponent<PointScript>().next_point;
            if (target == null)
            {
                VirusListManager.viruses.Remove(gameObject);
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals(TagManager.firewall_tag))
        {
            col.gameObject.GetComponent<Firewall>().health -= damage_output * Time.deltaTime;
        }
    }
}
