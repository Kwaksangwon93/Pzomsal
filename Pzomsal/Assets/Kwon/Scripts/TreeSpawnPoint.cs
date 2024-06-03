using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro.EditorUtilities;
using UnityEngine;

public class TreeSpawnPoint : MonoBehaviour
{
    [SerializeField]
    private Transform[] spawnPoint;
    public ResouercePoolManager resouercePoolManager;
    private int[] check;
    private int randomIndex;

    int count = 1;
    private void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
        check = new int[spawnPoint.Length];

        for(int i = 0; i < check.Length; i++)
        {
            check[i] = 0;
        }
    }

    private void Update()
    {
        if (count < spawnPoint.Length)
        {
            SetTree();
        }
    }

    private void SetTree()
    {
        randomIndex = Random.Range(1, spawnPoint.Length);
        if (check[randomIndex] == 0)
        {
            count++;
            check[randomIndex] = 1;
            GameObject tree = resouercePoolManager.GetTree();
            tree.transform.position = spawnPoint[randomIndex].position;
            
            var a = tree.gameObject.GetComponent<value>();
            a.qwe = randomIndex;
        }
    }
}
