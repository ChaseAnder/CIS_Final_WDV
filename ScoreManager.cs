// Chase Anderson

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI scoreText; // Reference to UI

    private int currentScore = 0; // Coins collected

    void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int value)
    {
        currentScore += value; // Adds score if player collects coin
        UpdateScoreText();
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("FinalScore", currentScore); // Save the score before transitioning
        PlayerPrefs.Save(); // Ensure it’s written to disk
    }

    private void UpdateScoreText()
    {
        scoreText.text = $"Coins: {currentScore}";
    }
}
