using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    public float speed;
    public bool canMove = true;
    public bool fall;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private Animator anim;
    [SerializeField]
    private CapsuleCollider2D Strech;

    Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        timer = gameObject.AddComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), 0);
            moveVelocity = moveInput * speed;
        }
        if (fall)
        {
            Strech.enabled = true;
        }
        else
        {
            Strech.enabled = false;
        }
    }

    void FixedUpdate()
    {
            rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime); 
    }

    void doubleJumpEnd()
    {
        anim.SetBool("is doubleJump", false);
        anim.SetBool("is fall", true);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer != 9)
        {
            anim.SetBool("is land", true);
            anim.SetBool("is jump", true);
            anim.SetBool("is fall", false);
        }
        if (collision.gameObject.tag.Substring(1,4) == "Jump" )
        {
            anim.SetBool("is doubleJump", true);
            Invoke("doubleJumpEnd", float.Parse(collision.gameObject.tag.Substring(0, 1)) * 0.6f);
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        anim.SetBool("is land", false);
        anim.SetBool("is jump", false);
        if (!anim.GetBool("is doubleJump") && !anim.GetBool("is fall"))
        {
            anim.SetBool("is fall", true);
        }
        
    }
}
