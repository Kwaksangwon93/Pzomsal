using UnityEngine;

public class CollisionAnimator : MonoBehaviour
{
    public Animator animator;  // �ִϸ����� ������Ʈ�� ����
    public string boolName = "isTriggered"; // �Ҹ��� �Ķ���� �̸�
    public int playerLayer; // �÷��̾� ���̾� ��ȣ

    void Start()
    {
        // �÷��̾� ���̾� ���� (�̸��� ���� ��������)
        playerLayer = LayerMask.NameToLayer("Player");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == playerLayer) // �浹�� ������Ʈ�� �÷��̾� ���̾��� ��
        {
            animator.SetBool(boolName, true); // �Ҹ��� ���� true�� �����Ͽ� �ִϸ��̼� ����
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == playerLayer) // �浹�� ������Ʈ�� �÷��̾� ���̾��� ��
        {
            animator.SetBool(boolName, false); // �Ҹ��� ���� false�� �����Ͽ� �ִϸ��̼� ����
        }
    }
}
