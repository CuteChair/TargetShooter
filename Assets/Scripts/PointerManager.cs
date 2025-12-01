using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointerManager : MonoBehaviour
{
    [SerializeField] private Image pointer;

    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
       Vector3 mousePos = Input.mousePosition;
       mousePos.z = 0;
       pointer.transform.position = mousePos;
    }
}
