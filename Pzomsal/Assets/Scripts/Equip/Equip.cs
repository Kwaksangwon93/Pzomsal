using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Equip : MonoBehaviour
{
    public WeaponType weaponType;

    public virtual void OnAttackInput(UnityAction Callback = null)
    {

    }

    public virtual void OnZoomInput(bool isZooming)
    {

    }
}