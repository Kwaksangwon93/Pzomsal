using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.Pool;

public class Arrow : MonoBehaviour
{
    public int damage = 20; // 화살 데미지

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // 플레이어 예외 처리
        {
            return;
        }

        if (collision.gameObject.TryGetComponent(out IDamagable damagable)) // 충돌한 오브젝트가 IDamagable을 구현한 오브젝트인지 확인
        {
            damagable.TakePhysicalDamage(damage); // 데미지를 입힘

            Destroy(gameObject); // 화살 제거
        }
    }
}
