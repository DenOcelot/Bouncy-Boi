using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMove : MonoBehaviour
{
    public float speed;
    public bool canMove = true;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private Animator anim;
    public ParticleSystem Death;

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
        if (anim.GetBool("is jump") && anim.GetBool("is land") && !anim.GetBool("is fall"))
        {

            anim.SetBool("is jump", true);
            anim.SetBool("is fall", true);
            anim.SetBool("is land", false);
        }
        if (anim.GetBool("is fall") && !anim.GetBool("is land"))
        {
            anim.SetBool("is jump", true);
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

    void die()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("Game");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer != 9)
        {
            anim.SetBool("is land", true);
            anim.SetBool("is jump", true);
            anim.SetBool("is fall", true);
        }
        else
        {
            anim.SetBool("is land", false);
        }
        if (anim.GetBool("is fall") && anim.GetBool("is jump") && !anim.GetBool("is land"))
        {
            anim.SetBool("is land", true);
        }
        if (collision.gameObject.tag == "Death")
        {
            Death.Play();
            Invoke("die", 0.5f);
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Substring(1, 4) == "Jump")
        {
            anim.SetBool("is fall", false);
            anim.SetBool("is land", true);
            anim.SetBool("is jump", true);
            anim.SetBool("is doubleJump", true);
            Invoke("doubleJumpEnd", float.Parse(collision.gameObject.tag.Substring(0, 1)) * 0.6f);
        }
        anim.SetBool("is land", false);
        anim.SetBool("is jump", false);
        if(!anim.GetBool("is doubleJump"))
        {
            anim.SetBool("is fall", true);
        }
    }
}
