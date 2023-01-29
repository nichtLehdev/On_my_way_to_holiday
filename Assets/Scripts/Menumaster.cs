using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using GlobalstatsIO;
using UnityEngine.SocialPlatforms.Impl;

public class Menumaster : MonoBehaviour
{
    public GameObject RankingWindow;
    public PrefabManager PrefabManager;
    public GameObject MainWindow;
    public GameObject UsernameWindow;
    public TMP_InputField InputField;
    public GameObject InternetError;

    private GlobalstatsIO.Leaderboard leaderboard;

    private void Start()
    {
        showNoInternet();
        MainWindow.SetActive(true);
        RankingWindow.SetActive(false);
        UsernameWindow.SetActive(false);
        Debug.Log(PlayerPrefs.GetString("username"));
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            if ((PlayerPrefs.GetString("username") == null || PlayerPrefs.GetString("username") == "") && (PlayerPrefs.GetString("skip_name") == null || PlayerPrefs.GetString("skip_name") == ""))
            {
                UsernameWindow.SetActive(true);
            }
        }
       
    }

    private void Update()
    {
        showNoInternet();
    }

    public void getLeaderboard()
    {
        var gs = new GlobalstatsIOClient(config.getId(), config.getSecret());
        string gtd = "score";
        int limit = 100;

        StartCoroutine(gs.GetLeaderboard(gtd, limit, LeaderboardCallback));
    }

    private void LeaderboardCallback(GlobalstatsIO.Leaderboard leaderboard)
    {
        if (leaderboard != null)
        {
            this.leaderboard = leaderboard;
        }
        else
        {

        }
    }

    private bool nameIsUsed(string name)
    {
        getLeaderboard();
        if(leaderboard != null)
        {
            foreach (LeaderboardValue item in this.leaderboard.data)
            {
                if(item.name == name) return true;
            }
        }
        return false;
    }

    public void setName()
    {
        var gs = new GlobalstatsIOClient(config.getId(), config.getSecret());
        string userName = InputField.text;
        if (userName != null && userName != "" && !nameIsUsed(userName)) {
            PlayerPrefs.SetString("username", userName);
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("score", "0");
            StartCoroutine(gs.Share(values, "", userName));
            UsernameWindow.SetActive(false);
        }

        
    }

    public void setSkip()
    {
        PlayerPrefs.SetString("skip_name", "skipped");
        UsernameWindow.SetActive(false);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void showRanking()
    {
        if (!InternetError.activeSelf)
        {
            MainWindow.SetActive(false);
            RankingWindow.SetActive(true);
            PrefabManager.showLeaderboard();
        }
        
    }

    private void showNoInternet()
    {
        if(Application.internetReachability == NetworkReachability.NotReachable)
        {
            InternetError.SetActive(true);
        }
        else
        {
            InternetError.SetActive(false);
        }
    }

    public void hideRanking()
    {
        MainWindow.SetActive(true);
        RankingWindow.SetActive(false);
    }

}
