using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : MonoBehaviour
{
    public TargetJoint2D Joint;
    public Vector2 Target1;
    public Vector2 Target2;
    // Start is called before the first frame update
    void Start()
    {
            Target1 = transform.position;
            Joint.target = Target1;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        if (pos.x <= Target1.x + 0.1f)
        {
            Joint.target = Target2;
        }
        if (pos.x >= Target2.x - 0.1f)
        {
            Joint.target = Target1;
        }
    }
}
