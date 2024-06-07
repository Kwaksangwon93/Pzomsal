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
        // �ʿ��� �ڿ� ����
        int requiredWood = 3;
        int requiredIron = 3;

        // �κ��丮���� �� �ڿ��� ���� Ȯ��
        int woodCount = GetItemCount(woodItem);
        int ironCount = GetItemCount(ironItem);

        if (woodCount >= requiredWood && ironCount >= requiredIron)
        {
            // �ʿ��� �ڿ��� ����
            RemoveResources(woodItem, requiredWood);
            RemoveResources(ironItem, requiredIron);


            DropItem(item);
            Debug.Log("���� ����!!");
        }
        else
        {
            Debug.Log("������ ����!!");
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
    // �ʿ��� �ڿ��� ������ �ִ��� Ȯ���ϴ� �޼���
    private bool HasEnoughResources(int requiredWood, int requiredIron)
    {
        int woodCount = GetItemCount(woodItem);
        int ironCount = GetItemCount(ironItem);

        return woodCount >= requiredWood && ironCount >= requiredIron;
    }

    // �κ��丮���� Ư�� �������� ������ ��ȯ�ϴ� �޼���
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

    // �ʿ��� �ڿ��� �κ��丮���� �����ϴ� �޼���
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

                // ������ ������ 0�� �Ǹ� ������ ���ϴ�.
                if (slot.quantity == 0)
                {
                    slot.item = null;
                }

                // ���� ������ 0�̸� ������Ʈ UI�� ȣ���մϴ�.
                if (quantity == 0)
                {
                    inventory.UpdateUI();
                    return;
                }
            }
        }

        // ��� ������ Ž���� �Ŀ��� quantity�� �����ִ� ��� UI�� ������Ʈ�մϴ�.
        inventory.UpdateUI();
    }


    // �������� ����ϴ� �޼���
    private void DropItem(ItemData item)
    {
        Instantiate(item.dropPrefab, dropPoint.position, Quaternion.identity);
    }
}
