using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.Pool;

public class Arrow : MonoBehaviour
{
    public int damage = 20; // 화살의 데미지

    private void OnCollisionEnter(Collision collision)
    {
        // 충돌한 오브젝트가 IDamagable을 구현한 오브젝트인지 확인
        if (collision.gameObject.TryGetComponent(out IDamagable damagable))
        {
            // 데미지를 입히는 메서드 호출
            damagable.TakePhysicalDamage(damage);

            // 화살 제거
            Destroy(gameObject);
        }
    }
}
