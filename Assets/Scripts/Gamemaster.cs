using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Gamemaster : MonoBehaviour
{
    private int coins;
    public GameObject ShopUI;
    

    // Start is called before the first frame update
    void Start()
    {
        coins = 0;
        
    }

    public void changeCoins( int coin )
    {
        coins += coin;
        ShopUI.GetComponent<shopitems>().refresh(coins);
    }

    public int getCoins()
    {
        return coins;
    }

    

    public void enterShop()
    {
        ShopUI.SetActive(true);
        ShopUI.GetComponent<shopitems>().refresh(coins);
    }

    public void closeShop()
    {
        ShopUI.SetActive(false);
    }
}
