using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class LiveTargetPoints : MonoBehaviour
{
    [SerializeField]
    private GameObject liveScoreGO;

    [SerializeField]
    private TextMeshProUGUI liveScoreTxt;

    [SerializeField]
    private TextMeshProUGUI liveScoreShadow;

    [SerializeField]
    private float upwardVelocity;

    [SerializeField]
    private float alphaTime;

    private void OnEnable()
    {
        print(liveScoreTxt.alpha);
    }

    private void OnDisable()
    {
        liveScoreTxt.alpha = 1;
        liveScoreShadow.alpha = 1;
    }


    private void Update()
    {
        transform.Translate(Vector3.up * upwardVelocity * Time.deltaTime);

        float alpha = Mathf.MoveTowards(liveScoreTxt.alpha, 0f, alphaTime); 

        liveScoreTxt.alpha = alpha;
        liveScoreShadow.alpha = alpha;

        if (alpha <= 0f)
        {
            gameObject.SetActive(false);
        }
    }

}
