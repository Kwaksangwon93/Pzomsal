using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private GameObject[] items = null;
    public int[] maxItemCount;
    private int[] currentCount;
    public float itemregen = 5f;
    private float curTime;

    private GameObject[] categoryObjects;

    private void Start()
    {
        currentCount = new int[items.Length];

        categoryObjects = new GameObject[maxItemCount.Length];

        for (int i = 0; i < maxItemCount.Length; i++)
        {
            categoryObjects[i] = new GameObject(items[i].name + "_Category");
        }
    }

    private void Update()
    {
        curTime += Time.deltaTime;
        if (curTime > itemregen)
        {
            curTime = 0;

            SpawnItem();
        }
    }

    private void SpawnItem()
    {
        int randIndex;

        while (true)
        {
            randIndex = Random.Range(0, items.Length);

            if (currentCount[randIndex] < maxItemCount[randIndex])
            {
                GameObject categoryObject = categoryObjects[randIndex];
                var item = Instantiate(items[randIndex]);

                Vector3 pos = new Vector3(player.transform.position.x + Random.Range(-15, 15), 20, player.transform.position.z + Random.Range(-15, 15));

                item.transform.parent = categoryObject.transform;

                item.transform.position = pos;
                currentCount[randIndex]++;
                break;
            }
            break;
        }
    }

    public void currentCountDown()
    {
        int maxIndex = 0;
        for (int i = 1; i < currentCount.Length; i++)
        {
            if (currentCount[i] > currentCount[maxIndex])
            {
                maxIndex = i;
            }
        }

        currentCount[maxIndex]--;
    }
}
