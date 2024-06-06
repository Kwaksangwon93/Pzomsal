using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.Pool;

public class Arrow : MonoBehaviour
{
    public int damage = 20; // ȭ�� ������

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // �÷��̾� ���� ó��
        {
            return;
        }

        if (collision.gameObject.TryGetComponent(out IDamagable damagable)) // �浹�� ������Ʈ�� IDamagable�� ������ ������Ʈ���� Ȯ��
        {
            damagable.TakePhysicalDamage(damage); // �������� ����

            Destroy(gameObject); // ȭ�� ����
        }
    }
}
