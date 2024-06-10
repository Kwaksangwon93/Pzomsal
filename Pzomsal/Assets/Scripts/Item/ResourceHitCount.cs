using UnityEngine;

public class ResourceHitCount : MonoBehaviour
{
    public ItemData itemToGive;
    public int quantityPerHit = 3;
    public int capacity;

    public void Gather(Vector3 hitPoint, Vector3 hitNormal)
    {
        for (int i = 0; i < quantityPerHit; i++)
        {
            if (capacity <= 0) break;

            capacity -= 1;
            Instantiate(itemToGive.dropPrefab, hitPoint + Vector3.up, Quaternion.LookRotation(hitNormal, Vector3.up));
        }

        if (capacity <= 0)
        {
            gameObject.SetActive(false);
            capacity = 1;
        }
    }
}