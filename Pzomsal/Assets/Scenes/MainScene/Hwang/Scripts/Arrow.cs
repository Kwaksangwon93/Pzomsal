using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.Pool;

public class Arrow : MonoBehaviour
{
    public int damage = 20; // ȭ�� ������
    public float rotationSpeed = 100f; // ȸ�� �ӵ�

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 direction = rb.velocity.normalized; // ȭ���� ����
        Quaternion targetRotation = Quaternion.LookRotation(direction); // ȸ�� ����

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime); // ȭ�� ȸ��
    }

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
