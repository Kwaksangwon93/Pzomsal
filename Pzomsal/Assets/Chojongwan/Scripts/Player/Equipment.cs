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
                if (curEquip.weaponType == WeaponType.Arrow && isZoomed)
                {
                    curEquip.OnAttackInput();
                }
                else
                {
                    curEquip.OnAttackInput();
                }
            }
        }
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