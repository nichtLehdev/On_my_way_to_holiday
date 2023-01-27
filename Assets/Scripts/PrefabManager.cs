using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using GlobalstatsIO;
using TMPro;

public class PrefabManager : MonoBehaviour
{
    public GameObject rowPrefab;
    public Transform rowsParent;

    public void showLeaderboard()
    {
        var gs = new GlobalstatsIOClient(config.getId(), config.getSecret());
        string gtd = "score";
        int limit = 100;

        StartCoroutine(gs.GetLeaderboard(gtd, limit, LeaderboardCallback));
    }

    private void LeaderboardCallback(Leaderboard leaderboard)
    {
        if (leaderboard != null)
        {
            foreach(Transform item in rowsParent)
            {
                Destroy(item.gameObject);
            }

            foreach (var item in leaderboard.data)
            {
                GameObject newGO = Instantiate(rowPrefab, rowsParent);
                TextMeshProUGUI[] texts = newGO.GetComponentsInChildren<TextMeshProUGUI>();
                texts[0].text = item.rank;
                texts[1].text = item.name;
                texts[2].text = item.value;
            }
            
        }
        else
        {

        }
    }
}
