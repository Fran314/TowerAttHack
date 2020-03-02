using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour
{
    public float speed = 2f;
    public float health = 100f;
    public float max_health = 100f;
    public float damage_output = 20f;
    public int priority = 1;
    public float awareness_increment = 20f;

    public Transform target;

    GameObject bug;

    private float threshold = 0.00001f;
    
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
                Destroy(gameObject);
            }
        }

        float angle = Vector3.Angle(move, Vector3.up);

        if(angle <= 45f)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if(angle <= 135f)
        {
            if (Vector3.Dot(move, Vector3.right) <= 0)
                transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            else
                transform.rotation = Quaternion.Euler(0f, 0f, -90f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 180f);
        }

        float xpos = transform.position.x;
        float decimal_x = xpos - Mathf.Floor(xpos);
        if (decimal_x >= 0.5f - threshold && decimal_x <= 0.5f + threshold) xpos = Mathf.Floor(xpos) + 0.5f;

        float ypos = transform.position.y;
        float decimal_y = ypos - Mathf.Floor(ypos);
        if (decimal_y >= 0.5f - threshold && decimal_y <= 0.5f + threshold) ypos = Mathf.Floor(ypos) + 0.5f;
        transform.position = new Vector3(xpos, ypos, 0);
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals(TagManager.firewall_tag))
        {
            col.gameObject.GetComponent<Firewall>().health -= damage_output * Time.deltaTime;
        }
    }
}
