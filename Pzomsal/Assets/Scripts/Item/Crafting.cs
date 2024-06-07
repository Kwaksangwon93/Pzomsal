using UnityEngine;
using static UnityEditor.Progress;
using static UnityEngine.Rendering.PostProcessing.SubpixelMorphologicalAntialiasing;

public class Crafting : MonoBehaviour
{
    public Transform dropPoint;
    public UIInventory inventory;

    public ItemData woodItem;
    public ItemData ironItem;
    public ItemData tape;
    public ItemData battery;
    public ItemData item;

    public void CraftPickaxe()
    {
        // 필요한 자원 수량
        int requiredWood = 3;
        int requiredIron = 3;

        // 인벤토리에서 각 자원의 수량 확인
        int woodCount = GetItemCount(woodItem);
        int ironCount = GetItemCount(ironItem);

        if (woodCount >= requiredWood && ironCount >= requiredIron)
        {
            // 필요한 자원을 제거
            RemoveResources(woodItem, requiredWood);
            RemoveResources(ironItem, requiredIron);


            DropItem(item);
            Debug.Log("제작 성공!!");
        }
        else
        {
            Debug.Log("아이템 부족!!");
        }
    }
    public void CraftArrow()
    {
        int requiredWood = 1;
        int woodCount = GetItemCount(woodItem);
        if(woodCount >= requiredWood)
        {
            RemoveResources(woodItem,requiredWood);
            for (int i = 0; i < 3; i++)
            DropItem(item);
        }
    }
    public void Bow()
    {
        int requiredWood = 15;
        int requiredtape = 1;

        int woodCount = GetItemCount(woodItem);
        int tapeCount = GetItemCount(tape);

        if(woodCount >= requiredWood && tapeCount >= requiredtape)
        {
            RemoveResources(woodItem, requiredWood);
            RemoveResources(ironItem, requiredtape);

            DropItem(item);
        }
    }
    public void Radio()
    {
        int requiredWood = 2;
        int requiredtape = 5;
        int requiredIron = 3;
        int requirdbattery = 2;

        int woodCount = GetItemCount(woodItem);
        int tapeCount = GetItemCount(tape);
        int ironCount = GetItemCount(ironItem);
        int batteryCount = GetItemCount(battery);

        if(woodCount >= requiredWood &&ironCount >= requiredIron && batteryCount >= requirdbattery && tapeCount >= requiredtape)
        {
            RemoveResources(woodItem, requiredWood);
            RemoveResources(ironItem, requiredIron);
            RemoveResources(tape, requiredtape);
            RemoveResources(battery, requirdbattery);

            DropItem(item);
        }
    }
    // 필요한 자원을 가지고 있는지 확인하는 메서드
    private bool HasEnoughResources(int requiredWood, int requiredIron)
    {
        int woodCount = GetItemCount(woodItem);
        int ironCount = GetItemCount(ironItem);

        return woodCount >= requiredWood && ironCount >= requiredIron;
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

                // 남은 수량이 0이면 업데이트 UI를 호출합니다.
                if (quantity == 0)
                {
                    inventory.UpdateUI();
                    return;
                }
            }
        }

        // 모든 슬롯을 탐색한 후에도 quantity가 남아있는 경우 UI를 업데이트합니다.
        inventory.UpdateUI();
    }


    // 아이템을 드랍하는 메서드
    private void DropItem(ItemData item)
    {
        Instantiate(item.dropPrefab, dropPoint.position, Quaternion.identity);
    }
}
