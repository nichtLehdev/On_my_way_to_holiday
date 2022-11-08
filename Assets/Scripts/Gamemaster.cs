using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemaster : MonoBehaviour
{
    private int coins;

    // Start is called before the first frame update
    void Start()
    {
        coins = 0;
    }

    public void changeCoins( int coin )
    {
        coins += coin;
    }

    public int getCoins()
    {
        return coins;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
