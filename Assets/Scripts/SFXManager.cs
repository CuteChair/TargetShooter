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
        //Explosions.OnEndExplosion += DisableCurrentExplosion;
    }

    private void OnDisable()
    {
        ClickOnTarget.OnClickAddSFX -= CreateExplosionAtPos;
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



       GameObject newExplosion = Instantiate(ExplosionAnimation, pos, Quaternion.identity);
       newExplosion.transform.localScale = scale;

       explosionPool.Add(newExplosion);

        print("No available explosion, created one. Explosion count : " + explosionPool.Count);

            //explosionPool.Add(NewExplosionAnim);
       // }
    }


}
