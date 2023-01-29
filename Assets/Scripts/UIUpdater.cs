using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using GlobalstatsIO;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class UIUpdater : MonoBehaviour
{
    public Gamemaster gamemaster;
    public TMPro.TextMeshProUGUI HighScoreText;
    public TMPro.TextMeshProUGUI CurrentScoreText;
    private GameObject coinCounter;
    private GameObject stopwatch;
    private float currentTime;
    private bool stopwatchActive = false;
    private float Score = 0;

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
        Debug.Log("Stopwatch stopped");
        stopwatchActive = false;
        this.Score = (int)(1000 / (currentTime / 1000) * (gamemaster.getCoins() + 5) / 5);

        if(PlayerPrefs.GetString("skip_name") != "skipped")
        {
            getLeaderboard();   
        }
        float highScoreOnScene = PlayerPrefs.GetFloat(SceneManager.GetActiveScene().buildIndex.ToString());
        if(highScoreOnScene < Score)
        {
            PlayerPrefs.SetFloat(SceneManager.GetActiveScene().buildIndex.ToString(), Score);
        }
        HighScoreText.text = highScoreOnScene.ToString();
        CurrentScoreText.text = Score.ToString();
        
    }

    private void CallbackMethod(bool success)
    {
        if (success)
        {
            Debug.Log("Values shared.");
        }
        else
        {
            // do something with error
        }
    }

    private void getLeaderboard()
    {
        var gs = new GlobalstatsIOClient(config.getId(), config.getSecret());
        string gtd = "score";
        int limit =100;

        StartCoroutine(gs.GetLeaderboard(gtd, limit, LeaderboardCallback));
    }

    private void LeaderboardCallback(GlobalstatsIO.Leaderboard leaderboard)
    {
        if(leaderboard != null)
        {
            string userName = PlayerPrefs.GetString("username");
            foreach (var item in leaderboard.data)
            {
                if (item.name == userName)
                {
                    float highScore = float.Parse(item.value);
                    if (highScore < Score)
                    {
                        var gs = new GlobalstatsIOClient(config.getId(), config.getSecret());
                        Dictionary<string, string> values = new Dictionary<string, string>();
                        values.Add("score", Score.ToString());
                        StartCoroutine(gs.Share(values, PlayerPrefs.GetString("id"), userName, CallbackMethod));
                        PlayerPrefs.SetFloat("highscore", Score);

                    }
                }
            }
        }
        else
        {

        }
    }

}