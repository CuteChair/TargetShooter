using System;
using UnityEngine;


public class TargetPositionManager : MonoBehaviour
{
    //Generates random positions for the targed inside the GameArea
    [Header("Assignable Components")]
    [SerializeField] private Transform gameAreaTransf;

    public Transform cubeTester; //for debug only

    [SerializeField] private Targets[] targets;

    Vector3 Max;
    Vector3 Min;

    private bool areTargetInitialized = false;
    private void OnEnable()
    {
        GameAreaManager.OnInitGameArea += SetMinMax;
        ClickOnTarget.OnClickedTarget += ChangeTargetPosition;
    }

    private void OnDisable()
    {
        GameAreaManager.OnInitGameArea -= SetMinMax;
        ClickOnTarget.OnClickedTarget -= ChangeTargetPosition;
    }

    private void Start()
    {
        
    }
    private void Update()
    {
        if (!areTargetInitialized)
            InitializeTargets(targets);
      
    }
    private void SetMinMax(Vector3 min, Vector3 max)
    {
        print($"Setting min : {min} | max : {max}");

        Min = min;
        Max = max;
    }
    private void InitializeTargets(Targets[] targets)
    {
        int targetCount = 0; 

        if (targets != null)
        {
            foreach (Targets target in targets)
            {
                Vector3 newPos = GenerateRandomPosition(target, Min, Max);

                //print(" Generated position : " + newPos);
                Instantiate(target.GetTargetPrefab(), newPos, Quaternion.identity);
                targetCount++;
            }
        }

        areTargetInitialized = true;
        GameManager.Instance.SetTargetCount(targetCount);
    }
    private void UpdateGameAreaSize()
    {
        if (gameAreaTransf != null)
        {
            //FindGameAreaMax(gameAreaTransf.position);
            //FindGameAreaMin(gameAreaTransf.position);
        }
    }

    private void ChangeTargetPosition(Targets target)
    {
        target.transform.position = GenerateRandomPosition(target, Min, Max);
    }

    private Vector3 GenerateRandomPosition(Targets target, Vector3 min, Vector3 max)
    {
        float halfSizeX = target.transform.localScale.x * 0.5f;
        float halfSizeY = target.transform.localScale.y * 0.5f;
        float x = UnityEngine.Random.Range(min.x + halfSizeX, max.x - halfSizeX);
        float y = UnityEngine.Random.Range(min.y + halfSizeY, max.y - halfSizeY);
        Vector3 newPos = new Vector3(x, y, 0);

        return newPos;
        
    }

   
}
