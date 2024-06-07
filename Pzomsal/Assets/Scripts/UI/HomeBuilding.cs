using UnityEngine;
using static UnityEditor.Progress;
using static UnityEngine.Rendering.PostProcessing.SubpixelMorphologicalAntialiasing;

public class HomeBuilding : MonoBehaviour
{
    public UIInventory inventory;

    public ItemData woodItem;
    public GameObject Home;

    private void Start()
    {
        Home.SetActive(false);
    }
    public void CreateHome()
    {
        int requiredWood = 19;

        int woodCount = GetItemCount(woodItem);

        if (requiredWood < woodCount)
        {
            RemoveResources(woodItem, requiredWood);

            Home.SetActive(true);
            Debug.Log("제작 성공!!");
        }
        else
        {
            Debug.Log("아이템 부족!!");
        }
    }
    public void CreateHome2()
    {
        int requiredWood = 44;

        int woodCount = GetItemCount(woodItem);

        if (requiredWood < woodCount)
        {
            RemoveResources(woodItem, requiredWood);

            Home.SetActive(true);
            Debug.Log("제작 성공!!");
        }
        else
        {
            Debug.Log("아이템 부족!!");
        }
    }
    // 필요한 자원을 가지고 있는지 확인하는 메서드
    private bool HasEnoughResources(int requiredWood)
    {
        int woodCount = GetItemCount(woodItem);

        return woodCount >= requiredWood;
    }

    // 인벤토리에서 특정 아이템의 수량을 반환하는 메서드
    private int GetItemCount(ItemData item)
    {
        int count = 0;
        foreach (ItemSlot slot in inventory.slots)
        {
            if (slot.item == item)
            {
                count += slot.quantity;
            }
        }
        return count;
    }

    // 필요한 자원을 인벤토리에서 제거하는 메서드
    private void RemoveResources(ItemData item, int quantity)
    {
        foreach (ItemSlot slot in inventory.slots)
        {
            if (slot.item == item)
            {
                if (slot.quantity >= quantity)
                {
                    slot.quantity -= quantity;
                    return;
                }
                else
                {
                    quantity -= slot.quantity;
                    slot.quantity = 0;
                }
            }
        }
    }
}
