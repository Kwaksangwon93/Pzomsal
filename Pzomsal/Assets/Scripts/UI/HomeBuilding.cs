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
            Debug.Log("���� ����!!");
        }
        else
        {
            Debug.Log("������ ����!!");
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
            Debug.Log("���� ����!!");
        }
        else
        {
            Debug.Log("������ ����!!");
        }
    }
    // �ʿ��� �ڿ��� ������ �ִ��� Ȯ���ϴ� �޼���
    private bool HasEnoughResources(int requiredWood)
    {
        int woodCount = GetItemCount(woodItem);

        return woodCount >= requiredWood;
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
