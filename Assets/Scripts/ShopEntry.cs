using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopEntry : MonoBehaviour
{
    public Gamemaster gamemaster;
    public GameObject Player;

    private bool isOpen;
    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(gameObject.transform.position,Player.transform.position);
        if ( distance <= 5.0f && !isOpen)
        {
            gamemaster.enterShop();
            isOpen = true;
        } else if ( distance > 6.0f && isOpen)
        {
            gamemaster.closeShop();
            isOpen = false;
        }
    }
}
