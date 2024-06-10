using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.SceneManagement; // UnityEditor.SceneManagement 대신 사용

public class ResouercePoolManager : MonoBehaviour
{
    public GameObject[] resouerces;

    List<GameObject>[] resouercePools;

    private void Awake()
    {
        resouercePools = new List<GameObject>[resouerces.Length];

        for (int i = 0; i < resouercePools.Length; i++)
        {
            resouercePools[i] = new List<GameObject>();
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        foreach (GameObject resouerce in resouercePools[index])
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
            select = Instantiate(resouerces[index], transform);
            resouercePools[index].Add(select);
        }

        return select;
    }
}
