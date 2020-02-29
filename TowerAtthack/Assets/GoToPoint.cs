using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToPoint : MonoBehaviour
{
    public Transform point;

    public float speed = 2f;
    public float min_dist = 0.1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(point.transform.position, transform.position) <= min_dist)
            if (point.childCount > 0)
                point = point.GetChild(0);
        transform.Translate((point.transform.position - transform.position).normalized * speed * Time.deltaTime);
    }
}
