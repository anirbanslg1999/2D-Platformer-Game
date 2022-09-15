using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    private int scoreCount = 0;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        SyncScore();
    }
    public void IncrementScore(int score)
    {   
        scoreCount += score;
        SyncScore();
    }

    public void SyncScore()
    {
        scoreText.text = "Score :" + scoreCount.ToString();
    }
}
