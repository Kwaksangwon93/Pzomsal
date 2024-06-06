using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Equipment : MonoBehaviour
{
    public Equip curEquip;
    public Transform equipParent;

    private PlayerController controller;
    private PlayerCondition condition;
    //public EquipTool equipTool;

    public bool isZoomed;

    public UIInventory inventory;

    private ItemSlot arrowSlot; // ȭ���� �ִ� ������ ������ ����

    void Start()
    {
        controller = CharacterManager.Instance.Player.controller;
        condition = CharacterManager.Instance.Player.condition;
    }

    public void OnAttackInput(InputAction.CallbackContext context)
    {
        if (curEquip != null && controller.canLook)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                Debug.Log("���ݽõ�");
                if (curEquip.weaponType == WeaponType.Arrow)
                {
                    if (isZoomed && InventoryContainsArrow()) // ���� �Ǿ� �ְ� ȭ���� 1�� �̻��� ��
                    {

                        curEquip.OnAttackInput();

                        arrowSlot.quantity--; // ȭ���� ����� �� ������ ����
                        if (arrowSlot.quantity <= 0)
                        {
                            arrowSlot.item = null;
                        }
                        inventory.UpdateUI();
                    }
                }
                else
                {
                    Debug.Log("����");
                    curEquip.OnAttackInput();
                }
            }
        }
    }

    bool InventoryContainsArrow()
    {
        if (inventory == null) return false;

        foreach (ItemSlot slot in inventory.slots)
        {
            if (slot.item != null && slot.item.displayName == "ȭ��" && slot.quantity > 0)
            {
                arrowSlot = slot; // ȭ���� �ִ� ���� ����
                return true;
            }
        }

        arrowSlot = null; // ȭ���� ���� ��� null�� ����
        return false;
    }

    public void OnZoomInput(InputAction.CallbackContext context)
    {
        if (curEquip != null && controller.canLook && curEquip.weaponType == WeaponType.Arrow)
        {
            if (context.phase == InputActionPhase.Performed) // ������ ���� ��
            {
                curEquip.OnZoomInput(true);

                isZoomed = true;
            }
            else if (context.phase == InputActionPhase.Canceled) // ���� ��
            {
                curEquip.OnZoomInput(false);

                isZoomed = false;
            }
        }
    }

    public void EquipNew(ItemData data)
    {
        UnEquip();
        curEquip = Instantiate(data.equipPrefab, equipParent).GetComponent<Equip>();

        curEquip.weaponType = data.weaponType;
    }

    public void UnEquip()
    {
        if (curEquip != null)
        {
            Destroy(curEquip.gameObject);
            curEquip = null;
        }
    }
}