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

    private int numberOfStages => Mathf.CeilToInt(stageData.MaxScale / stageData.ScaleModifier);
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
            if (currentScale < stageData.MaxScale)
            {
                PointsAllowed();
                DownScaleTarget();
            }
        }
    }

    private void DownScaleTarget()
    {
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
