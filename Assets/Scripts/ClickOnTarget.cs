using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnTarget : MonoBehaviour
{
    public static event Action<Vector3, Vector3> OnClickAddSFX;
    public static event Action<Targets> OnClickedTarget;
    public static event Action OnAddToStreak;
    public static event Action OnBreakStreak;

    private Targets clickedTarget;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CastRay();
        }
    }

    private void CastRay()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null)
        {
            clickedTarget = hit.collider.GetComponent<Targets>();
            Vector3 position = clickedTarget.transform.position;
            Vector3 scale = clickedTarget.transform.localScale;

            if (clickedTarget != null)
            {
                //print("Clicked on target");
                OnClickedTarget?.Invoke(clickedTarget);

                OnClickAddSFX?.Invoke(position, scale);


                OnAddToStreak?.Invoke();

            }
        }
        else
            OnBreakStreak?.Invoke();

    }
}
