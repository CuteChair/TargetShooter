using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAreaManager : MonoBehaviour
{
    //This script handles the GameArea size to match the MainCamera FOV;
    public static event Action<Vector3, Vector3> OnInitGameArea;

    [Header("Assignable Components")]
    [SerializeField] private Transform gameAreaTransf;
    [SerializeField] private Camera mainCam;

    private float gameAreaHeight;
    private float gameAreaWidth;

    private float currentCamAspect;

    private Vector3 Max;
    private Vector3 Min;

    private void Awake()
    {
        if (gameAreaTransf == null)
        {
            gameAreaTransf = GetComponent<Transform>();
        }

        FindGameAreaMax(gameAreaTransf.position);
        FindGameAreaMin(gameAreaTransf.position);

        //if (mainCam == null)
        //{
        //    mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        //}
    }

    private void Start()
    {
        OnInitGameArea?.Invoke(Min, Max);
    }
    private void Update()
    {
        //if (currentCamAspect != mainCam.aspect)
        //{
        //    ScaleGameArea();
        //    currentCamAspect = mainCam.aspect;
        //}
    }
    private void FindGameAreaMax(Vector3 center)
    {
        float maxX = center.y + (gameAreaTransf.localScale.x * 0.5f);
        float maxY = center.x + (gameAreaTransf.localScale.y * 0.5f);
        Max = new Vector3(maxX, maxY, 0f);
        //print(Max);
    }

    private void FindGameAreaMin(Vector3 center)
    {
        float minX = -1f * (center.y + (gameAreaTransf.localScale.x * 0.5f));
        float minY = -1f * (center.x + (gameAreaTransf.localScale.y * 0.5f));
        Min = new Vector3(minX, minY, 0f);
        //print(Min);
    }
    //private void ScaleGameArea()
    //{
    //    gameAreaHeight = mainCam.orthographicSize * 2f;
    //    gameAreaWidth = gameAreaHeight * mainCam.aspect;

    //    if (gameAreaTransf != null)
    //    gameAreaTransf.localScale = new Vector3(gameAreaWidth, gameAreaHeight, 0f);

    //    OnChangedGameAreaScale?.Invoke();

    //    //print($"Rescaled GameArea size to H: {gameAreaHeight}, W: {gameAreaWidth}");
    //}
}
