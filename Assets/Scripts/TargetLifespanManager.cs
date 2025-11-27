using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLifespanManager : MonoBehaviour
{
    [SerializeField] private ScriptableTarget targetData;
    private Targets currentTarget;
    private float timer;

    private void OnEnable()
    {
        ClickOnTarget.OnClickedTarget += AddTime;
    }

    private void OnDisable()
    {
        ClickOnTarget.OnClickedTarget -= AddTime;   
    }

    private void Awake()
    {
        timer = targetData.DefaultTargetTimer;

        currentTarget = GetComponent<Targets>();
    }
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void AddTime(Targets target)
    {
        if (target == currentTarget)
        {
            print("Adding time to : " + gameObject.name);
            timer += 5f;
        }
    }


}
