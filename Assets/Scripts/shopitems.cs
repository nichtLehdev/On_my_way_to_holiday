using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class shopitems : MonoBehaviour
{

    public GameObject[] shopitem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void refresh(int coins)
    {

        for(int i = 0; i < shopitem.Length; i++)
        {
            if (int.Parse(shopitem[i].transform.Find("Price").GetComponent<TMP_Text>().text) < coins)
            {
                shopitem[i].SetActive(true);
            } else
            {
                shopitem[i].SetActive(false);
            }
        }

    }
}
