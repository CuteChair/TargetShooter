using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour 
{
    [SerializeField] private ScriptableTarget targetData;
    private GameObject targetPrefab;
    private void OnEnable()
    {
        Initialize();
    }
    private void Initialize()
    {
        if (targetData != null)
        {
            targetPrefab = targetData.TargetPrefab;
        }
    }

    public GameObject GetTargetPrefab()
    {
        return targetData.TargetPrefab;
    }
}
