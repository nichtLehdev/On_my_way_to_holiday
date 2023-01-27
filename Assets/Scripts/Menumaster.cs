using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Menumaster : MonoBehaviour
{
    public GameObject RankingWindow;
    public PrefabManager PrefabManager;
    public GameObject MainWindow;
    public GameObject UsernameWindow;
    public TMP_InputField InputField;

    private void Start()
    {
        
        MainWindow.SetActive(true);
        RankingWindow.SetActive(false);
        UsernameWindow.SetActive(false);
        Debug.Log(PlayerPrefs.GetString("username"));
        if ((PlayerPrefs.GetString("username") == null || PlayerPrefs.GetString("username") == "") && (PlayerPrefs.GetString("skip_name") == null || PlayerPrefs.GetString("skip_name") == ""))
        {
            UsernameWindow.SetActive(true);
        }
    }

    public void setName()
    {
        PlayerPrefs.SetString("username", InputField.text);
        UsernameWindow.SetActive(false);
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
        MainWindow.SetActive(false);
        RankingWindow.SetActive(true);
        PrefabManager.showLeaderboard();
    }

    public void hideRanking()
    {
        MainWindow.SetActive(true);
        RankingWindow.SetActive(false);
    }

}
