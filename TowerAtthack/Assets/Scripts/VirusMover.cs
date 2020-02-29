using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusMover : MonoBehaviour
{
    private Transform target;
    private int point_index = 0;

    public float speed = 2f;
    public float min_dist = 0.01f;

    GameObject bug;

    // Start is called before the first frame update
    void Start()
    {
        target = TPoints.points[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) <= min_dist)
            if (point_index < TPoints.size - 1)
            {
                point_index++;
                target = TPoints.points[point_index];
            }
            else
            {
                Destroy(gameObject);
            }

        Vector3 move = target.position - transform.position;
        Vector3 move_adjusted = move.normalized * speed * Time.deltaTime;
        if (move_adjusted.magnitude < move.magnitude) move = move_adjusted;
        transform.Translate(move, Space.World);
    }
}
