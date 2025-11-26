using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.U2D;

public class TargetPositionManager : MonoBehaviour
{
    //Generates random positions for the targed inside the GameArea
    [Header("Assignable Components")]
    [SerializeField] private Transform gameAreaTransf;

    public Transform cubeTester; //for debug only

    public int numberOfTargets;
    private Targets[] targets;

    Vector3 Max;
    Vector3 Min;

    private void OnEnable()
    {
        GameAreaManager.OnChangedGameAreaScale += UpdateGameAreaSize;
    }

    private void OnDisable()
    {
        GameAreaManager.OnChangedGameAreaScale -= UpdateGameAreaSize;
    }
    private void Update()
    {
        
    }

    private void UpdateGameAreaSize()
    {
        if (gameAreaTransf != null)
        {
            FindGameAreaMax(gameAreaTransf.position);
            FindGameAreaMin(gameAreaTransf.position);
        }
    }
    private void GenerateRandomPosition(Targets target)
    {
        Vector3 center = gameAreaTransf.position;
        
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
