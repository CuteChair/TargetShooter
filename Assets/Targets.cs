using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour 
{
    [SerializeField] private ScriptableTarget targetData;
    private GameObject targetPrefab;
    private float timer;

    private void OnEnable()
    {
        Initialize();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Initialize()
    {
        if (targetData != null)
        {
            targetPrefab = targetData.TargetPrefab;
            timer = targetData.DefaultTargetTimer;
        }
    }

    public GameObject GetTargetPrefab()
    {
        return targetData.TargetPrefab;
    }

    public void AddToTimer(float amout)
    {
        timer += amout;
    }
}
