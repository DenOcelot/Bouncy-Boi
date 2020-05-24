using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public TargetJoint2D Joint;
    public Animator anim;
    public Vector2 Target1;
    public Vector2 Target2;
    // Start is called before the first frame update
    void Start()
    {
        Joint = gameObject.GetComponent<TargetJoint2D>();
        anim = gameObject.GetComponent<Animator>();
        Target1 = transform.position;
        Target2 = new Vector2(Target1.x + 5f, Target1.y);
        Joint.target = Target2;
    }
    void check()
    {
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        if (pos.x <= Target1.x + 0.1f)
        {
            anim.SetBool("direction", true);
            Joint.target = Target2;
        }
        if (pos.x >= Target2.x - 0.1f)
        {
            anim.SetBool("direction", false);
            Joint.target = Target1;
        }
    }
    // Update is called once per frame
    void Update()
    {

        Invoke("check", 0.1f);
    }
}
