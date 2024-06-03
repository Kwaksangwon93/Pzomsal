using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor.SceneManagement;
using UnityEngine;

public class ResouercePoolManager : MonoBehaviour
{
    public GameObject[] resouerces;

    List<GameObject>[] resouercePools;


    private void Awake()
    {
        resouercePools = new List<GameObject>[resouerces.Length];

        for(int i = 0; i < resouercePools.Length; i++)
        {
            resouercePools[i] = new List<GameObject>();
        }
    }

    public GameObject GetTree()
    {
        GameObject select = null;

        foreach (GameObject resouerce in resouercePools[0])
        {
            if (!resouerce.activeSelf)
            {
                select = resouerce;
                select.SetActive(true);
                break;
            }
        }

        if (select == null)
        {
            select = Instantiate(resouerces[0], transform);
            resouercePools[0].Add(select);
        }


        return select;
    }


    public GameObject GetIron()
    {
        GameObject select = null;

        foreach (GameObject resouerce in resouercePools[1])
        {
            if (!resouerce.activeSelf)
            {
                select = resouerce;
                select.SetActive(true);
                break;
            }
        }

        if (select == null)
        {
            select = Instantiate(resouerces[1], transform);
            resouercePools[1].Add(select);
        }


        return select;
    }

}
