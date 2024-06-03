using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private GameObject[] items = null;
    public float itemregen = 5f;
    public float curTime;

    private void SpawnItem()
    {
        int rand = Random.Range(0, items.Length);
        var item = Instantiate(items[rand]);
        Vector3 pos = new Vector3(player.transform.position.x + Random.Range(-15, 15), 20, player.transform.position.z + Random.Range(-15, 15));
        item.transform.position = pos;
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
}
