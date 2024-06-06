using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.Pool;

public class Arrow : MonoBehaviour
{
    public int damage = 20; // 화살 데미지
    public float rotationSpeed = 100f; // 회전 속도

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 direction = rb.velocity.normalized; // 화살의 방향
        Quaternion targetRotation = Quaternion.LookRotation(direction); // 회전 각도

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime); // 화살 회전
    }

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
