using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class UIUpdater : MonoBehaviour
{
    public Gamemaster gamemaster;
    private GameObject coinCounter;
    private GameObject stopwatch;
    private float currentTime;
    private bool stopwatchActive = false;

    // Start is called before the first frame update
    void Start()
    {
        coinCounter = GameObject.Find("CoinCounter");
        stopwatch = GameObject.Find("Stopwatch");
        currentTime = 0;
        stopwatchActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        coinCounter.GetComponent<TMPro.TextMeshProUGUI>().text = gamemaster.getCoins().ToString();

        if (stopwatchActive == true)
        {
            currentTime = currentTime + Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        if (time.Minutes == 0)
        {
            stopwatch.GetComponent<TMPro.TextMeshProUGUI>().text = time.ToString(@"ss\.fff");
        }
        else
        {
            stopwatch.GetComponent<TMPro.TextMeshProUGUI>().text = time.ToString(@"mm\:ss");
        }
    }
    public void startStopwatch()
    {
        stopwatchActive = true;
    }

    public void stopStopwatch() { 
        stopwatchActive = false;
        int Score = (int)(1000 / (currentTime / 1000) * (gamemaster.getCoins() + 5) / 5);
        PlayerPrefs.SetFloat(SceneManager.GetActiveScene().buildIndex.ToString(), Score);
    
    }
}