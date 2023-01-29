using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject shopshield;
    public Gamemaster gamemaster;
    public PlayerController playerController;

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
            respawn();
        } else
        {
            shopshield.GetComponent<Button>().enabled = true;
            StartCoroutine(shield());
        }
        
    }

    void respawn()
    {
        if(gamemaster.getCoins() >= 50 && !Vector3.Equals(gamemaster.getLastCheckoint(), gamemaster.getFirstCheckoint()))
        {
            gamemaster.changeCoins(-50);
            this.gameObject.transform.position = gamemaster.getLastCheckoint();
            playerController.isGrounded = true;
        } else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
