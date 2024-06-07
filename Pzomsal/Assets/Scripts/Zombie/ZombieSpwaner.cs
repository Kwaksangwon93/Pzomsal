using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieSpawner : MonoBehaviour
{
    public static ZombieSpawner Instance { get; private set; }

    public GameObject zombiePrefab;
    public int maxZombieCount;
    public float minDistanceToPlayer = 10f; // �÷��̾�� �ּ� �Ÿ�
    public float spawnRadius = 50f; // ���� ����

    private Transform playerTransform; // �÷��̾��� ��ġ

    private Vector3 randomPosition;

    private Bounds bounds;
    private Vector3 mapCenter; // ���� �߽�

    private GameObject zombies;
    private int currentZombieCount; // ���� ���� ��
    public float spawnInterval = 20f; // ���� �� Ȯ���ϴ� �ð� ����
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

        bounds = GetComponent<Collider>().bounds; // ���� �ݶ��̴� ũ��
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
        ZombiespawnTimer -= Time.deltaTime; // ���� Ÿ�̸� ����

        if (ZombiespawnTimer <= 0f) // �ð��� 0�ʰ� �Ǹ� ����
        {
            ZombiespawnTimer = spawnInterval; // ���� Ÿ�̸� �ʱ�ȭ

            if (currentZombieCount < maxZombieCount) // ���� ���� �� Ȯ���ϰ� �������� ����
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

            //randomPosition = new Vector3(Random.Range(bounds.min.x, bounds.max.x), bounds.center.y, Random.Range(bounds.min.z, bounds.max.z)); // ���������� ������ ��ġ�� �޾ƿ�

            float distanceToPlayer = Vector3.Distance(randomPosition, playerTransform.position); // �÷��̾���� �Ÿ�

            NavMeshHit hit;
            Vector3 defaultPosition = Vector3.zero;

            match = distanceToPlayer >= minDistanceToPlayer;

            if (match) // �ּ� ���� �ٱ��� ���� ����
            {
                if (NavMesh.SamplePosition(randomPosition, out hit, bounds.size.magnitude / 2, NavMesh.AllAreas))
                {
                    return hit.position;
                }
            }
        } while (!match);

        return Vector3.zero; // Ȥ�� �� ���� ó��
    }

    public void ZombieKilled()
    {
        currentZombieCount--; // ���� ���� �� ����
    }
}