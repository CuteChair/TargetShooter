using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLifespanManager : MonoBehaviour
{
    [SerializeField] private ScriptableTarget targetData;
    private Targets currentTarget;
    private float timer;
    private float timerBuffer;

    private void OnEnable()
    {
        ClickOnTarget.OnClickedTarget += AddTime;
        TargetStage.OnTargetNewStage += UpdateTimebuffer;
    }

    private void OnDisable()
    {
        ClickOnTarget.OnClickedTarget -= AddTime;   
        TargetStage.OnTargetNewStage -= UpdateTimebuffer;
    }

    private void Awake()
    {
        timer = targetData.DefaultTargetTimer;
        timerBuffer += targetData.MaxTimeBuffer;


        currentTarget = GetComponent<Targets>();
    }
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Destroy(gameObject);
            GameManager.Instance.OnRemovedTarget();
        }
    }

    private void AddTime(Targets target)
    {
        if (target == currentTarget)
        {
            //print("Adding time to : " + gameObject.name);
            timer += timerBuffer;

            if (timer >= targetData.MaxLifeSpan)
            {
                timer = targetData.MaxLifeSpan; 
            }

            //print("Remaining Time : " + timer);
        }
    }

    private void UpdateTimebuffer()
    {
        if (timerBuffer > targetData.MinTimeBuffer)
        {
            timerBuffer -= targetData.ReduceTimeBuffer;
            //print("Time buffer : " + timerBuffer);
        }
    }


}
