using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;
    public int ZombieCount;
    public float minDistanceToPlayer = 10f; // 플레이어와 최소 거리

    private Transform playerTransform; // 플레이어의 위치

    Vector3 randomPosition;

    Bounds bounds;

    private void Awake()
    {
        bounds = GetComponent<Collider>().bounds; // 맵의 콜라이더 크기
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
            randomPosition = new Vector3(Random.Range(bounds.min.x, bounds.max.x), bounds.center.y, Random.Range(bounds.min.z, bounds.max.z)); // 범위내에서 랜덤한 위치를 받아옴

            float distanceToPlayer = Vector3.Distance(randomPosition, playerTransform.position); // 플레이어와의 거리

            NavMeshHit hit;
            Vector3 defaultPosition = Vector3.zero;

            match = distanceToPlayer >= minDistanceToPlayer;

            if (match) // 최소 범위 바깥에 좀비 생성
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