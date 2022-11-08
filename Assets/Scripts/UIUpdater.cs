using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIUpdater : MonoBehaviour
{
    public Gamemaster gamemaster;
    private GameObject coinCounter;
    // Start is called before the first frame update
    void Start()
    {
        coinCounter = GameObject.Find("CoinCounter");
    }

    // Update is called once per frame
    void Update()
    {
        coinCounter.GetComponent<TMPro.TextMeshProUGUI>().text = gamemaster.getCoins().ToString();
    }
}
