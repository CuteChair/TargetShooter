using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //public static event Action<LiveTargetPoints, int> OnReturnPoints;

    public static ScoreManager Instance;

    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private TextMeshProUGUI StreakText;
    [SerializeField] private Image streakBar;
    
    private float score;

    private int streakModifier;
    
    private int currentStreakProgress;

    private int currentGivenPoints;

    private LiveTargetPoints currentRequestTarget;

    [SerializeField] private int inRowNeeded;
    [SerializeField] private int maxStreak;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;


        score = 0;
        streakModifier = 1;
        currentStreakProgress = 0;
        UpdateScoreText(0);
        UpdateStreakUI();
    }

    private void OnEnable()
    {
        //LiveTargetPoints.OnRequestLivePoints += 
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

    private void CalculateCurrentGivenPoints(float amout)
    {
        int newPoints = Mathf.FloorToInt(amout * streakModifier);
        currentGivenPoints = newPoints;
    }
    private void AddScore(float amount)
    {
        CalculateCurrentGivenPoints(amount);

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

    public int GetCurrentPoints()
    {
        return currentGivenPoints;
    }
    public int RequestFinalScore()
    {
        int currentScore = Mathf.FloorToInt(score);

        return currentScore;
    }
}
