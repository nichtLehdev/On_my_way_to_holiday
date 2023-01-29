using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject shopshield;
    public GameObject shopdice;
    public GameObject playershield;
    public GameObject projectile;
    public Gamemaster gamemaster;
    public PlayerController playerController;

    private bool shieldactive;
    private bool isshooting;
    // Start is called before the first frame update
    void Start()
    {
        shieldactive = false;
        isshooting = true;
    }

    public void callshot()
    {
        Debug.Log("DONE");
        StartCoroutine(shoot());
    }

    public void kill()
    {
        if(!shieldactive)
        {
            respawn();
        } else
        {
            playershield.SetActive(false);
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
        playershield.SetActive(true);
        shieldactive = true;
    }

    public void buydice()
    {
        isshooting = false;
    }

    IEnumerator shield()
    {
        yield return new WaitForSeconds(3);
        shieldactive = false;
    }

    public IEnumerator shoot()
    {
        if (isshooting == false)
        {
            isshooting = true;
            if(this.gameObject.transform.localScale.x == -1)
            {
                projectile.GetComponent<Projectile>().speed = 4;
            } else
            {
                projectile.GetComponent<Projectile>().speed = -4;
            }
            Instantiate(projectile, this.transform.position, this.transform.rotation);
            yield return new WaitForSeconds(1.5f);
            isshooting = false;
        }
    }
}
