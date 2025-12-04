using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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

    [SerializeField] private int inRowNeeded;
    [SerializeField] private int maxStreak;

    private void Awake()
    {
        score = 0;
        streakModifier = 1;
        currentStreakProgress = 0;
        UpdateScoreText(0);
        UpdateStreakUI();
    }

    private void OnEnable()
    {
        TargetStage.OnAddScore += AddScore;
        ClickOnTarget.OnAddToStreak += AddToStreakProgress;
        ClickOnTarget.OnBreakStreak += BreakStreak;
    }

    private void OnDisable()
    {
        TargetStage.OnAddScore -= AddScore;
        ClickOnTarget.OnAddToStreak -= AddToStreakProgress;
        ClickOnTarget.OnBreakStreak -= BreakStreak;
    }
    private void AddScore(float amount)
    {
       // print("Adding Score");
        score += amount * streakModifier;
        int scoreRepresentation = Mathf.FloorToInt(score);
        UpdateScoreText(scoreRepresentation);
       // print("Score Representation : " + scoreRepresentation);
    }
    
    private void UpdateScoreText(int newScore)
    {
        //print("Add score to text");
        if (ScoreText != null)
        ScoreText.text = newScore.ToString();
    }

    private void AddToStreakProgress()
    {
        currentStreakProgress++;
   
        CheckForStreak();
        UpdateStreakUI();
    }

    private void CheckForStreak()
    {
        if (currentStreakProgress == inRowNeeded)
        {
            streakModifier++;

            if (streakModifier >= maxStreak)
                streakModifier = maxStreak;

            currentStreakProgress = 0;
        }
    }
    private void BreakStreak()
    {
        currentStreakProgress = 0;
        streakModifier = 1;
        UpdateStreakUI();
    }

    private void UpdateStreakUI()
    {
        StreakText.text = streakModifier.ToString();
        streakBar.fillAmount = (float)currentStreakProgress / inRowNeeded;

    }
}
