using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.Pool;

public class Arrow : MonoBehaviour
{
    public int damage = 20; // ȭ���� ������

    private void OnCollisionEnter(Collision collision)
    {
        // �浹�� ������Ʈ�� IDamagable�� ������ ������Ʈ���� Ȯ��
        if (collision.gameObject.TryGetComponent(out IDamagable damagable))
        {
            // �������� ������ �޼��� ȣ��
            damagable.TakePhysicalDamage(damage);

            // ȭ�� ����
            Destroy(gameObject);
        }
    }
}
