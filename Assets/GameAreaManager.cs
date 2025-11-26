using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAreaManager : MonoBehaviour
{
    //This script handles the GameArea size to match the MainCamera FOV;

    [Header("Required Components")]
    [SerializeField] private Transform gameAreaTransf;
    [SerializeField] private Camera mainCam;

    private float gameAreaHeight;
    private float gameAreaWidth;

    private float currentCamAspect;

    private void Awake()
    {
        if (gameAreaTransf == null)
        {
            gameAreaTransf = GetComponent<Transform>();
        }

        if (mainCam == null)
        {
            mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        }
    }

    private void Start()
    {
        if (mainCam != null)
        {
            ScaleGameArea();
            currentCamAspect = mainCam.aspect;
        }
    }
    private void Update()
    {
        if (currentCamAspect != mainCam.aspect)
        {
            ScaleGameArea();
            currentCamAspect = mainCam.aspect;
        }
    }

    private void ScaleGameArea()
    {
        gameAreaHeight = mainCam.orthographicSize * 2f;
        gameAreaWidth = gameAreaHeight * mainCam.aspect;

        if (gameAreaTransf != null)
        gameAreaTransf.localScale = new Vector3(gameAreaWidth, gameAreaHeight, 0f);

        print($"Rescaled GameArea size to H: {gameAreaHeight}, W: {gameAreaWidth}");
    }
}
