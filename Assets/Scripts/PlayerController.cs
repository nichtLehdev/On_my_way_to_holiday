using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public bool isGrounded = false;

    public float speed = 5;
    public float jump = 5;
    public float jumpmultiplyer = 1.25f;

    private Animator m_Anim;

    void Start()
    {
        m_Anim = this.gameObject.transform.Find("sword_man").GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        float direction = Input.GetAxis("Horizontal") + Input.acceleration.x;
        transform.Translate(Vector2.right * speed * direction * Time.deltaTime);

        if(direction > -0.25 && direction < 0.25 )
        {
            m_Anim.Play("Idle");
        } else
        {
            if(direction > 0)
            {
                transform.localScale = new Vector3(false ? 1 : -1, 1, 1);
            } else
            {
                transform.localScale = new Vector3(true ? 1 : -1, 1, 1);            }
            m_Anim.Play("Run");
        }

        if((Input.GetKeyDown(KeyCode.Space) && isGrounded == true) || isGrounded && Input.acceleration.z < -1.2f)
        {
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
            isGrounded = false;
            m_Anim.Play("Jump");
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
    }

    public void buyjumpBoost()
    {
        jump = jump * jumpmultiplyer;
    }
}
