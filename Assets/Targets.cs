using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.Rendering;
using UnityEngine;

public class Targets : MonoBehaviour
{
    [SerializeField] private ScriptableTarget targetData;
    [SerializeField] private Transform targetTransf;
    [SerializeField] private GameObject targetPrefab;
    private float timer;

    private void OnEnable()
    {
        Initialize();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
    }

    private void Initialize()
    {
        if (targetData != null && targetTransf != null)
        {
            transform.localScale = targetData.DefaultTargetSize;
            timer = targetData.DefaultTargetTimer;
        }
    }
}
