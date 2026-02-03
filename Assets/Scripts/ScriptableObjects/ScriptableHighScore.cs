using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Data", fileName = "Scriptable/HighScoreData")]
public class ScriptableHighScore : ScriptableObject
{
    public int CurrentHighScore;

    public void CompareScore(int newScore)
    {
        if (newScore > CurrentHighScore)
        {
            CurrentHighScore = newScore;
        }
    }
}
