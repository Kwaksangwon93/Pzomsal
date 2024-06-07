using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class value : MonoBehaviour
{

    public int index;

    // �ڿ��� ���� �Ǵ� ö�ΰ��� ���� �Ʒ� �ϳ��� ��ü�� null�� ��� ������.
    // �̿� �ش� ��ü�� null ���¶�� ���� �޼����� ����Ƽ �ֿܼ� �����ִµ�, ���࿡ ������ �ִ� ���� �ƴ�.
    public TreeSpawnPoint? treeSpawnPoint;
    public IronSpawnPoint? ironSpawnPoint;

    private void Awake()
    {
        treeSpawnPoint = null;
        ironSpawnPoint = null;
    }

    private void OnDisable()
    {
        if (treeSpawnPoint != null)
        {
            treeSpawnPoint.Disable(index);
        }
        else if (ironSpawnPoint != null)
        {
            ironSpawnPoint.Disable(index);
        }
    }
}
