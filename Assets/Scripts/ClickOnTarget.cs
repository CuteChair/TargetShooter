using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnTarget : MonoBehaviour
{
    public static event Action<Targets> OnClickedTarget;
    private void OnMouseDown()
    {
        Targets currentTarget = GetComponent<Targets>();
        OnClickedTarget?.Invoke(currentTarget);
    }
}
