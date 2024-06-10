using UnityEngine;

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
                    quantity = 0;
                }
                else
                {
                    quantity -= slot.quantity;
                    slot.quantity = 0;
                }

                // 슬롯의 수량이 0이 되면 슬롯을 비웁니다.
                if (slot.quantity == 0)
                {
                    slot.item = null;
                }
            }
        }

        // 모든 슬롯을 탐색한 후에도 quantity가 남아있는 경우 UI를 업데이트합니다.
        inventory.UpdateUI();
    }
}
