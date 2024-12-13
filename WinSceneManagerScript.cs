// Chase Anderson
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Use this for TextMeshPro

public class WinSceneManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI winSceneScoreText;

    void Start()
    {
        // Access the current score from the ScoreManager
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);

        // Display the final score
        winSceneScoreText.text = $"Total Coins Collected: {finalScore}";
    }
}
