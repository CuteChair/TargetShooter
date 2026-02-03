using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int targetCount;

    [SerializeField]
    private GameObject gameOverCanvas;

    [SerializeField]
    private GameObject scoreCanvas;

    [SerializeField]
    private TextMeshProUGUI finalScoreText;

    [SerializeField]
    private TextMeshProUGUI highScoreText;

    [SerializeField]
    private ScriptableHighScore highScoreSO;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public void SetTargetCount(int targets)
    {
        targetCount = targets;
        print("number of targets : " + targetCount);
    }

    public void OnRemovedTarget()
    {
        targetCount--;

        print("Remaining targtets : "  + targetCount);

        if (targetCount == 0)
            OnGameEnded();
    }

    private void OnGameEnded()
    {
        int finalScore = ScoreManager.Instance.RequestFinalScore();

        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true);
            scoreCanvas.SetActive(false);

            finalScoreText.text = ($"Score : {finalScore.ToString()}");

            if (highScoreSO != null)
            {
                highScoreSO.CompareScore(finalScore);
            }

            if (highScoreText != null)
                highScoreText.text = ("High score : " + highScoreSO.CurrentHighScore.ToString());
        }
    }


    public void OnRestart()
    {
        SceneManager.LoadScene("GameScene");
    }
}
