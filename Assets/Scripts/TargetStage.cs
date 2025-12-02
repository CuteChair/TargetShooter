using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TargetStage : MonoBehaviour
{
    public static event Action OnTargetNewStage;
    public static event Action<float> OnAddScore;

    [SerializeField] private ScriptableTargetStage stageData;

    private Targets currentTarget;

    private int numberOfStages;
    private int currentStage;

    private float currentPoint;
    private float pointModifier => stageData.MaxPoints / numberOfStages;

    private void Awake()
    {
        currentTarget = GetComponent<Targets>();
        currentStage = 1;
        currentPoint = Mathf.CeilToInt(stageData.MinPoints);
        numberOfStages = GetNumberOfStages();
    }

    private void OnEnable()
    {
        ClickOnTarget.OnClickedTarget += CickedOnTarget;
        //ClickOnTarget.OnClickedTarget += UpdateCurrentStage;
       // print("Min : " + stageData.MinScale + " Scale modifier : " + stageData.ScaleModifier + " Nb of stages : " + numberOfStages);
    }

    private void OnDisable()
    {
        ClickOnTarget.OnClickedTarget -= CickedOnTarget;
    }

    private void CickedOnTarget(Targets target)
    {
        if (currentTarget != null && target == currentTarget)
        {
            if (currentStage < numberOfStages)    //This line is probably why the score is not counting up after a certain point. When the object reaches min scale this becomes false
            {
                DownScaleTarget();
                PointsAllowed();
                UpdateCurrentStage();
            }
            else if (currentStage == numberOfStages)
            {
                PointsAllowed();
                print("Only giving points");
            }
        }
    }

    private void DownScaleTarget()
    {

        float newX = transform.localScale.x - stageData.ScaleModifier;
        float newY = transform.localScale.y - stageData.ScaleModifier;

        transform.localScale = new Vector3(newX, newY, transform.localScale.z);

    }
    private void UpdateCurrentStage()
    {
            currentStage++;
            print("Stage " + currentStage + " of " + numberOfStages);
            OnTargetNewStage?.Invoke();
    }

    private void PointsAllowed()
    {
        currentPoint += pointModifier;

        if (currentPoint >= stageData.MaxPoints)
            currentPoint = stageData.MaxPoints;

        if (currentStage == numberOfStages && currentPoint != stageData.MaxPoints)
            currentPoint = stageData.MaxPoints;

        OnAddScore?.Invoke(currentPoint);
    }

    private int GetNumberOfStages()
    {
        float diff = transform.localScale.x - stageData.MinScale;
        int stages = Mathf.FloorToInt(diff / stageData.ScaleModifier);

        return stages;
    }
}
