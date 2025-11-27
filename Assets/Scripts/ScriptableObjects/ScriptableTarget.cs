using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ScriptableTarget", order = 1)]
public class ScriptableTarget : ScriptableObject
{
    public GameObject TargetPrefab;
    public Vector3 DefaultTargetSize;
    public float DefaultTargetTimer;
}
