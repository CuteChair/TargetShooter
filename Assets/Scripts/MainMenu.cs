using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{   
    public void OnClickStart()
    {
        SceneManager.LoadScene("GameScene");
    }
}
