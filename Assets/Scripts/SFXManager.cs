using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField]
    private GameObject ExplosionAnimation;

    [SerializeField]
    private List<GameObject> explosionPool = new List<GameObject>();
    private void OnEnable()
    {
        ClickOnTarget.OnClickAddSFX += CreateExplosionAtPos;
    }

    private void OnDisable()
    {
        ClickOnTarget.OnClickAddSFX -= CreateExplosionAtPos;
    }

    private void CreateExplosionAtPos(Vector3 pos, Vector3 scale)
    {
        //if (explosionPool.Count > 0)
        //{
        //    for (int i = 0; i < explosionPool.Count; i++)
        //    {
        //        if (!explosionPool[i].activeSelf)
        //        {
        //            explosionPool[i].SetActive(true);
        //            explosionPool[i].transform.position = pos;
        //            explosionPool[i].transform.localScale = scale;

        //            return;
        //        }

        //        GameObject NewExplosionAnim = ExplosionAnimation;
        //        NewExplosionAnim.transform.localScale = scale;

        //        Instantiate(NewExplosionAnim, pos, Quaternion.identity);

        //        explosionPool.Add(NewExplosionAnim);

        //    }
        //}
        //else
        //{
            GameObject NewExplosionAnim = ExplosionAnimation;
            NewExplosionAnim.transform.localScale = scale;

            Instantiate(NewExplosionAnim, pos, Quaternion.identity);

            explosionPool.Add(NewExplosionAnim);
       // }
    }
}
