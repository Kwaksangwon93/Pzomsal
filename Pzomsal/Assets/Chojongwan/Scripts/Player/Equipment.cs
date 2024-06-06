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

    private ItemSlot arrowSlot; // 화살이 있는 슬롯을 저장할 변수

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
                Debug.Log("공격시도");
                if (curEquip.weaponType == WeaponType.Arrow)
                {
                    if (isZoomed && InventoryContainsArrow()) // 줌이 되어 있고 화살이 1개 이상일 때
                    {

                        curEquip.OnAttackInput();

                        arrowSlot.quantity--; // 화살을 사용한 후 수량을 감소
                        if (arrowSlot.quantity <= 0)
                        {
                            arrowSlot.item = null;
                        }
                        inventory.UpdateUI();
                    }
                }
                else
                {
                    Debug.Log("공격");
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
            if (slot.item != null && slot.item.displayName == "화살" && slot.quantity > 0)
            {
                arrowSlot = slot; // 화살이 있는 슬롯 저장
                return true;
            }
        }

        arrowSlot = null; // 화살이 없는 경우 null로 설정
        return false;
    }

    public void OnZoomInput(InputAction.CallbackContext context)
    {
        if (curEquip != null && controller.canLook && curEquip.weaponType == WeaponType.Arrow)
        {
            if (context.phase == InputActionPhase.Performed) // 누르고 있을 때
            {
                curEquip.OnZoomInput(true);

                isZoomed = true;
            }
            else if (context.phase == InputActionPhase.Canceled) // 뗐을 때
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