using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronSpawnPoint : MonoBehaviour
{
    [SerializeField]
    private Transform[] spawnPoint;
    public ResouercePoolManager resouercePoolManager;

    private int randomIndex;
    private int saveIndex;

    private int[] check;
    private float[] respawnTime;


    private void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();

        check = new int[spawnPoint.Length];
        respawnTime = new float[spawnPoint.Length];

        for (int i = 0; i < check.Length; i++)
        {
            check[i] = 0;
            respawnTime[i] = 0f;
        }
    }

    private void Update()
    {
        for (int i = 0; i < respawnTime.Length; i++)
        {
            if (respawnTime[i] <= 0)
                continue;

            respawnTime[i] -= Time.deltaTime;
        }

        SetIron();
    }

    public void SetIron()
    {
        randomIndex = Random.Range(1, spawnPoint.Length);
        saveIndex = randomIndex;

        if (check[saveIndex] == 0 && respawnTime[saveIndex] <= 0)
        {
            check[saveIndex] = 1;
            GameObject tree = resouercePoolManager.Get(1);
            tree.transform.position = spawnPoint[randomIndex].position;

            if (tree.transform.GetComponent<value>().ironSpawnPoint == null)
                tree.transform.GetComponent<value>().ironSpawnPoint = this;

            tree.transform.GetComponent<value>().index = saveIndex;
        }
    }

    public void Disable(int index)
    {
        check[index] = 0;
        respawnTime[index] = 60f;
    }
}
