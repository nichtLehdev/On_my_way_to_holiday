using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Gamemaster : MonoBehaviour
{
    private int coins;
    public GameObject ShopUI;
    public GameObject Shootbtn;
    public GameObject FinishUI;
    public UIUpdater uiupdater;

    private Vector3 firstCheckpoint;
    private Vector3 lastCheckpoint;

    // Start is called before the first frame update
    void Start()
    {
        firstCheckpoint = GameObject.Find("Player").transform.position;
        lastCheckpoint = GameObject.Find("Player").transform.position;
        coins = 0;
        Time.timeScale = 1;
        Debug.Log(firstCheckpoint);
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

    
    public void enterShop(Vector3 checkpoint)
    {
        lastCheckpoint = checkpoint;
        ShopUI.SetActive(true);
        ShopUI.GetComponent<shopitems>().refresh(coins);
        Shootbtn.SetActive(false);
    }

    public void closeShop()
    {
        ShopUI.SetActive(false);
        Shootbtn.SetActive(true);
    }

    public void finish()
    {
        uiupdater.stopStopwatch();
        FinishUI.SetActive(true);
        Shootbtn.SetActive(false);
        Time.timeScale = 0;
    }

    public Vector3 getLastCheckoint()
    {
        return lastCheckpoint;
    }

    public Vector3 getFirstCheckoint()
    {
        return firstCheckpoint;
    }
}
