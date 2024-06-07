using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieSpawner : MonoBehaviour
{
    public static ZombieSpawner Instance { get; private set; }

    public GameObject zombiePrefab;
    public int maxZombieCount;
    public float minDistanceToPlayer = 10f; // 플레이어와 최소 거리
    public float spawnRadius = 50f; // 스폰 범위

    private Transform playerTransform; // 플레이어의 위치

    private Vector3 randomPosition;

    private Bounds bounds;
    private Vector3 mapCenter; // 맵의 중심

    private GameObject zombies;
    private int currentZombieCount; // 현재 좀비 수
    public float spawnInterval = 20f; // 좀비 수 확인하는 시간 간격
    private float ZombiespawnTimer;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        bounds = GetComponent<Collider>().bounds; // 맵의 콜라이더 크기
        mapCenter = bounds.center;
        playerTransform = CharacterManager.Instance.transform;

        zombies = new GameObject("Zombies");
        currentZombieCount = 0;
    }

    private void Start()
    {
        for (int i = 0; i < maxZombieCount; i++)
        {
            SpawnZombie();
        }

        ZombiespawnTimer = spawnInterval;
    }

    private void Update()
    {
        ZombiespawnTimer -= Time.deltaTime; // 스폰 타이머 감소

        if (ZombiespawnTimer <= 0f) // 시간이 0초가 되면 실행
        {
            ZombiespawnTimer = spawnInterval; // 스폰 타이머 초기화

            if (currentZombieCount < maxZombieCount) // 현재 좀비 수 확인하고 생성할지 결정
            {
                int zombiesToSpawn = maxZombieCount - currentZombieCount;

                for (int i = 0; i < zombiesToSpawn; i++)
                {
                    SpawnZombie();
                }
            }
        }
    }

    void SpawnZombie()
    {
        Vector3 randomPosition = GetRandomNavMeshPosition();

        GameObject zombie = Instantiate(zombiePrefab, randomPosition, Quaternion.identity);
        zombie.transform.parent = zombies.transform;

        currentZombieCount++;
    }

    Vector3 GetRandomNavMeshPosition()
    {
        bool match;

        do
        {
            Vector3 randomDirection = Random.insideUnitSphere * spawnRadius;
            randomDirection.y = 5f;
            randomPosition = mapCenter + randomDirection;

            //randomPosition = new Vector3(Random.Range(bounds.min.x, bounds.max.x), bounds.center.y, Random.Range(bounds.min.z, bounds.max.z)); // 범위내에서 랜덤한 위치를 받아옴

            float distanceToPlayer = Vector3.Distance(randomPosition, playerTransform.position); // 플레이어와의 거리

            NavMeshHit hit;
            Vector3 defaultPosition = Vector3.zero;

            match = distanceToPlayer >= minDistanceToPlayer;

            if (match) // 최소 범위 바깥에 좀비 생성
            {
                if (NavMesh.SamplePosition(randomPosition, out hit, bounds.size.magnitude / 2, NavMesh.AllAreas))
                {
                    return hit.position;
                }
            }
        } while (!match);

        return Vector3.zero; // 혹시 모를 예외 처리
    }

    public void ZombieKilled()
    {
        currentZombieCount--; // 현재 좀비 수 감소
    }
}