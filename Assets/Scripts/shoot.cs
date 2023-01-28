using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public GameObject projectile;
    public int delay;

    private bool isshooting;
    // Start is called before the first frame update
    void Start()
    {
        isshooting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isshooting)
        {
            StartCoroutine(addProjectile());
        }
    }

    IEnumerator addProjectile()
    {
        isshooting = true;
        yield return new WaitForSeconds(delay);
        Instantiate(projectile, this.transform.position, this.transform.rotation);
        isshooting = false;
    }
}
