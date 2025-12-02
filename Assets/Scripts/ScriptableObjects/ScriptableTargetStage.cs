using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ScriptableTargetStage", order = 2)]
public class ScriptableTargetStage : ScriptableObject
{
    public float MinScale;
    public float ScaleModifier;
    public float MaxPoints;
    public float MinPoints;
}
