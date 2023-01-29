using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int speed = 1;
    public bool friendly = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "ground")
        {
            Destroy(this.gameObject);
        }

        if (!friendly)
        {

            if (col.gameObject.tag == "Player")
            {
                col.gameObject.GetComponent<PlayerInteraction>().kill();
            }

        } else
        {
            if (col.gameObject.tag == "Enemy")
            {
                Destroy(col.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}
