using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempProtoScript : MonoBehaviour
{
    public GameObject Text;
    public Gamemaster gameMaster;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameMaster.getCoins() >= 10)
        {
            Text.SetActive(true);
        }
    }
}
