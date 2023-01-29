using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Level1()
    {
        SceneManager.LoadScene(2);
    }
}
