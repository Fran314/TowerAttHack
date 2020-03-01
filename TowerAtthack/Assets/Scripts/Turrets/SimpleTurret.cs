using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTurret : MonoBehaviour
{
    public float range = 2f;
    public float fire_rate = 2f;
    public float damage_output = 10f;

    public Object bullet_prefab;

    private Transform target = null;
    private float fire_cooldown = 0f;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.1f);
    }
    
    void Update()
    {
        fire_cooldown -= Time.deltaTime;

        if (target != null)
        {
            Vector3 dir = target.position - transform.position;
            Vector3 projection = Vector3.ProjectOnPlane(dir, transform.forward);
            float angle = Vector3.Angle(projection, Vector3.up);
            if (Vector3.Dot(projection, Vector3.right) <= 0)
                transform.rotation = Quaternion.Euler(0f, 0f, angle);
            else
                transform.rotation = Quaternion.Euler(0f, 0f, -angle);


            if (fire_cooldown <= 0)
            {
                Shoot();
                fire_cooldown = 1 / fire_rate;
            }
        }
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject) Instantiate(bullet_prefab, transform.position + (transform.up * 0.55f), transform.rotation);
        Bullet bullet_script = bulletGO.GetComponent<Bullet>();
        bullet_script.setTarget(target);
        bullet_script.damage_output = damage_output;
    }

    void UpdateTarget()
    {
        GameObject[] viruses = VirusListManager.getVirusesArray();

        float min_dist = Mathf.Infinity;
        int max_pr = -1000;
        Transform nearest = null;
        foreach(GameObject virus in viruses)
        {
            float dist = Vector3.Distance(transform.position, virus.transform.position);
            if (dist <= range)
            {
                if (virus.GetComponent<Virus>().priority > max_pr)
                {
                    min_dist = dist;
                    max_pr = virus.GetComponent<Virus>().priority;
                    nearest = virus.transform;
                }
                else if (virus.GetComponent<Virus>().priority == max_pr && dist < min_dist)
                {
                    min_dist = dist;
                    max_pr = virus.GetComponent<Virus>().priority;
                    nearest = virus.transform;
                }
            }
        }

        if (nearest != null) target = nearest;
        else target = null;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
