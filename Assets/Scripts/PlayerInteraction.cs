using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject shopshield;

    private bool shieldactive;
    // Start is called before the first frame update
    void Start()
    {
        shieldactive = false;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void kill()
    {
        if(!shieldactive)
        {
            Destroy(this.gameObject);
        } else
        {
            shopshield.GetComponent<Button>().enabled = true;
            StartCoroutine(shield());
        }
        
    }

    public void buyshield()
    {
        shopshield.GetComponent<Button>().enabled = false;
        shieldactive = true;
    }

    IEnumerator shield()
    {
        yield return new WaitForSeconds(3);
        shieldactive = false;
    }
}
