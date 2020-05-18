using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;

    public Vector2 offset = Vector2.up * 5;
    public float speed = 2;
    public float size = 20;
    public float min_dist = 0.5f;
    public bool CamMov = true;

    Vector2 dir;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Camera cam = GetComponent<Camera>();
        cam.orthographicSize = size;
    }

    // Update is called once per frame
    void Update()
    {
        if (CamMov)
        {
            dir = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);
        }
        else
        {
            dir = new Vector2(transform.position.x, transform.position.y);
        }

        dir += offset;
        if (dir.sqrMagnitude > min_dist * min_dist)
        {
            transform.position += (Vector3)dir * speed * Time.deltaTime;
        }
    }
}
