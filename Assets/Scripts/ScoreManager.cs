using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private TextMeshProUGUI StreakText;
    [SerializeField] private Image streakBar;
    
    private float score;

    private int streakModifier;
    
    private int currentStreakProgress;

    private void Awake()
    {
        score = 0;
        streakModifier = 1;
        currentStreakProgress = 0;
        UpdateScoreText(0);
        UpdateStreakBar();
    }

    private void OnEnable()
    {
        TargetStage.OnAddScore += AddScore;
        ClickOnTarget.OnAddToStreak += AddToStreak;
        ClickOnTarget.OnBreakStreak += BreakStreak;
    }

    private void OnDisable()
    {
        TargetStage.OnAddScore -= AddScore;
        ClickOnTarget.OnAddToStreak -= AddToStreak;
        ClickOnTarget.OnBreakStreak -= BreakStreak;
    }
    private void AddScore(float amount)
    {
        score += amount * streakModifier;
        int scoreRepresentation = Mathf.FloorToInt(score);
        UpdateScoreText(scoreRepresentation);
    }
    
    private void UpdateScoreText(int newScore)
    {
        if (ScoreText != null)
        ScoreText.text = newScore.ToString();
    }

    private void AddToStreak()
    {
        currentStreakProgress++;
        UpdateStreakBar();

        if (currentStreakProgress >= 8)
        {
            streakModifier = 2;
            UpdateStreakText();
            UpdateStreakBar();
        }
        else if (currentStreakProgress >= 16)
        {
            streakModifier = 3;
            UpdateStreakText();
            UpdateStreakBar();
        }
        else if (currentStreakProgress >= 24)
        {
            streakModifier = 4;
            UpdateStreakText();
            UpdateStreakBar();
        }
    }

    private void BreakStreak()
    {
        currentStreakProgress = 0;
        streakModifier = 1;
        UpdateStreakText();
    }

    private void UpdateStreakText()
    {
        StreakText.text = streakModifier.ToString();
    }
    private void UpdateStreakBar()
    {
        
        if (currentStreakProgress < 8)
        {
            streakBar.fillAmount = currentStreakProgress / 8;
        }
        else if (currentStreakProgress >= 8)
        {
            streakBar.fillAmount = currentStreakProgress / 16;
        }
        else if (currentStreakProgress >= 16)
        {
            streakBar.fillAmount = currentStreakProgress / 24;
        }
    }
}
