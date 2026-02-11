using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField]
    private GameObject explosionAnimationPrefab;
   
    [SerializeField]
    private GameObject pointEffectAnimPrefab;

    [SerializeField]
    private List<GameObject> explosionPool = new List<GameObject>();

    [SerializeField]
    private List<GameObject> pointsEffectPool = new List<GameObject>();
    private void OnEnable()
    {
        ClickOnTarget.OnClickAddSFX += CreateExplosionAtPos;
        ClickOnTarget.OnClickAddPointsEffect += CreatePointEffects;
        //Explosions.OnEndExplosion += DisableCurrentExplosion;
    }

    private void OnDisable()
    {
        ClickOnTarget.OnClickAddSFX -= CreateExplosionAtPos;
        ClickOnTarget.OnClickAddPointsEffect += CreatePointEffects;
        //Explosions.OnEndExplosion += DisableCurrentExplosion;
    }

    private void CreateExplosionAtPos(Vector3 pos, Vector3 scale)
    {
        if(explosionPool.Count > 0)
        {
            for (int i = 0; i < explosionPool.Count; i++)
            {
                if (!explosionPool[i].activeSelf)
                {
                    explosionPool[i].transform.position = pos;
                    explosionPool[i].transform.localScale = scale;
                    explosionPool[i].SetActive(true);

                    print("Reused : " + explosionPool[i].name);

                    return;
                }
            }
        }



       GameObject newExplosion = Instantiate(explosionAnimationPrefab, pos, Quaternion.identity);
       newExplosion.transform.localScale = scale;

       explosionPool.Add(newExplosion);

        print("No available explosion, created one. Explosion count : " + explosionPool.Count);

            //explosionPool.Add(NewExplosionAnim);
       // }
    }

    private void CreatePointEffects(Vector3 newPos)
    {
        if (pointsEffectPool.Count < 0 || pointsEffectPool == null)
            return;


        for (int i = 0; i < pointsEffectPool.Count; i++)
        {
            if (!pointsEffectPool[i].activeSelf)
            {
                pointsEffectPool[i].transform.position = newPos;
                pointsEffectPool[i].SetActive(true);

                return;
            }
        }

        GameObject newPointEffect = Instantiate(pointEffectAnimPrefab, newPos, Quaternion.identity);

        pointsEffectPool.Add(newPointEffect);

    }


}
