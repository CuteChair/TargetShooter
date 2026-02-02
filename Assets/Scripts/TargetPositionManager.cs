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
        GameAreaManager.OnChangedGameAreaScale += UpdateGameAreaSize;
        ClickOnTarget.OnClickedTarget += ChangeTargetPosition;
    }

    private void OnDisable()
    {
        GameAreaManager.OnChangedGameAreaScale -= UpdateGameAreaSize;
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

    private void InitializeTargets(Targets[] targets)
    {
        if (targets != null)
        {
            foreach (Targets target in targets)
            {
                GenerateRandomPosition(target);
                Instantiate(target.GetTargetPrefab(), GenerateRandomPosition(target), Quaternion.identity);
            }
        }

        areTargetInitialized = true;
        
    }
    private void UpdateGameAreaSize()
    {
        if (gameAreaTransf != null)
        {
            FindGameAreaMax(gameAreaTransf.position);
            FindGameAreaMin(gameAreaTransf.position);
        }
    }

    private void ChangeTargetPosition(Targets target)
    {
        target.transform.position = GenerateRandomPosition(target);
    }

    private Vector3 GenerateRandomPosition(Targets target)
    {
        float halfSizeX = target.transform.localScale.x * 0.5f;
        float halfSizeY = target.transform.localScale.y * 0.5f;
        float x = UnityEngine.Random.Range(Min.x + halfSizeX, Max.x - halfSizeX);
        float y = UnityEngine.Random.Range(Min.y + halfSizeY, Max.y - halfSizeY);
        Vector3 newPos = new Vector3(x, y, 0);

        return newPos;
        
    }

    private void FindGameAreaMax(Vector3 center)
    {
        float maxX = center.y + (gameAreaTransf.localScale.x * 0.5f);
        float maxY = center.x + (gameAreaTransf.localScale.y * 0.5f);
        Max = new Vector3(maxX, maxY, 0f);
    }

    private void FindGameAreaMin(Vector3 center)
    {
        float minX = -1f * (center.y + (gameAreaTransf.localScale.x * 0.5f));
        float minY = -1f * (center.x + (gameAreaTransf.localScale.y * 0.5f));
        Min = new Vector3(minX, minY, 0f);
    }
}
