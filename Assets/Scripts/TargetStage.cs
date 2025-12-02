using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TargetStage : MonoBehaviour
{
    public static event Action OnDownScaleTarget;
    public static event Action<float> OnAddScore;

    [SerializeField] private ScriptableTargetStage stageData;

    private float currentScale;

    private Targets currentTarget;

    private int numberOfStages => Mathf.CeilToInt(stageData.MinScale / stageData.ScaleModifier);
    private int currentStage;

    private float currentPoint;
    private float pointModifier => stageData.MaxPoints / numberOfStages;

    private void Awake()
    {
        currentTarget = GetComponent<Targets>();
        currentStage = 1;
        currentPoint = Mathf.CeilToInt(stageData.MinPoints);
    }

    private void OnEnable()
    {
        ClickOnTarget.OnClickedTarget += CickedOnTarget;
        ClickOnTarget.OnClickedTarget += UpdateCurrentStage;
    }

    private void OnDisable()
    {
        ClickOnTarget.OnClickedTarget -= CickedOnTarget;
        ClickOnTarget.OnClickedTarget -= UpdateCurrentStage;
    }

    private void CickedOnTarget(Targets target)
    {
        if (currentTarget != null && target == currentTarget)
        {
            if (currentScale < stageData.MinScale)    //This line is probably why the score is not counting up after a certain point. When the object reaches min scale this becomes false
            {
                PointsAllowed();
                DownScaleTarget();
            }
        }
    }

    private void DownScaleTarget()
    {
        //This method needs to be refactored because its confusing and not really logical : instead of multiplying scale modif then substracting it just subtract it.
        float tLocalScaleX = transform.localScale.x;
        float tLocalScaleY = transform.localScale.y;

        float xScale = tLocalScaleX * stageData.ScaleModifier;
        float yScale = tLocalScaleY * stageData.ScaleModifier;

        transform.localScale = new Vector3(tLocalScaleX - xScale, tLocalScaleY - yScale, 0);

        currentScale += stageData.ScaleModifier;

        OnDownScaleTarget?.Invoke();

    }
    private void UpdateCurrentStage(Targets target)
    {
        if (currentTarget != null && target == currentTarget)
        {
            currentStage++;

                if(currentStage > numberOfStages)
                {
                    currentStage = numberOfStages;
                }
        }
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

}
