using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject canon;
    public GameObject spawnManager;
    public GameObject ui;
    public TMP_Text leaderboardText;
    // Start is called before the first frame update
    void Start()
    {
        SetGameActive(false);
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        SetGameActive(true);
    }

    public void EndGame(int score)
    {
        SetGameActive(false);
        UpdateScore(score);
    }

    private void SetGameActive(bool state)
    {
        canon.SetActive(state);
        spawnManager.SetActive(state);
        ui.SetActive(!state);
    }
    private void UpdateScore(int score)
    {
        leaderboardText.text = "";
        List<int> leaderboardScore = new List<int>(6);
        for (int i = 0; i < 5; i++)
        {
            leaderboardScore.Add(PlayerPrefs.GetInt(i.ToString(), 0));
        }
        leaderboardScore.Add(score);

        leaderboardScore.Sort();
        leaderboardScore.Reverse();

        for (int i = 0; i < 5; i++)
        {
            leaderboardText.text += (i + 1).ToString() + ": " + leaderboardScore[i].ToString() + '\n';
            PlayerPrefs.SetInt(i.ToString(), leaderboardScore[i]);
        }

        PlayerPrefs.Save();
    }
}
