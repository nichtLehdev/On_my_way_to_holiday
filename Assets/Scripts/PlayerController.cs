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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        float direction = Input.GetAxis("Horizontal") + Input.acceleration.x;
        transform.Translate(Vector2.right * speed * direction * Time.deltaTime);

        if((Input.GetKeyDown(KeyCode.Space) && isGrounded == true) || isGrounded && Input.acceleration.z < -1.2f)
        {
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
            isGrounded = false;
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
