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
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true);
            scoreCanvas.SetActive(false);

            finalScoreText.text = ($"Score : {ScoreManager.Instance.RequestFinalScore()}");
        }
    }


    public void OnRestart()
    {
        SceneManager.LoadScene("GameScene");
    }
}
