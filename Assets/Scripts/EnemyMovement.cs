using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public int direction = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 oldPos = transform.position;
        transform.Translate(Vector2.right * direction * Time.deltaTime);
    }

    public void flip() {
        direction *= -1;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "ground")
        {
            flip();
        }
    }
}
