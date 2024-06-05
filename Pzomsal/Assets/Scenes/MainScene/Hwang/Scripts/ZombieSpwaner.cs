using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;
    public int ZombieCount;
    public float minDistanceToPlayer = 10f; // �÷��̾�� �ּ� �Ÿ�

    private Transform playerTransform; // �÷��̾��� ��ġ

    Vector3 randomPosition;

    Bounds bounds;

    private void Awake()
    {
        bounds = GetComponent<Collider>().bounds; // ���� �ݶ��̴� ũ��
        playerTransform = CharacterManager.Instance.transform;
    }

    private void Start()
    {
        for (int i = 0; i < ZombieCount; i++)
        {
            SpawnZombie();
        }
    }

    void SpawnZombie()
    {
        Vector3 randomPosition = GetRandomNavMeshPosition();

        Instantiate(zombiePrefab, randomPosition, Quaternion.identity);
    }

    Vector3 GetRandomNavMeshPosition()
    {
        bool match;

        do
        {
            randomPosition = new Vector3(Random.Range(bounds.min.x, bounds.max.x), bounds.center.y, Random.Range(bounds.min.z, bounds.max.z)); // ���������� ������ ��ġ�� �޾ƿ�

            float distanceToPlayer = Vector3.Distance(randomPosition, playerTransform.position); // �÷��̾���� �Ÿ�

            NavMeshHit hit;
            Vector3 defaultPosition = Vector3.zero;

            match = distanceToPlayer >= minDistanceToPlayer;

            if (match) // �ּ� ���� �ٱ��� ���� ����
            {
                if (NavMesh.SamplePosition(randomPosition, out hit, bounds.size.magnitude / 2, NavMesh.AllAreas))
                {
                    defaultPosition = hit.position;
                }

                return defaultPosition;
            }
        } while (!match);

        return Vector3.zero;
    }
}