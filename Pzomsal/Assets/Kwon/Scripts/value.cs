using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class value : MonoBehaviour
{

    public int index;

    // �ڿ��� ���� �Ǵ� ö�ΰ��� ���� �Ʒ� �ϳ��� ��ü�� null�� ��� ������.
    // �̿� �ش� ��ü�� null ���¶�� ���� �޼����� ����Ƽ �ֿܼ� �����ִµ�, ���࿡ ������ �ִ� ���� �ƴ�.
    public TreeSpawnPoint treeSpawnPoint = null;
    public IronSpawnPoint ironSpawnPoint = null;

    private void OnDisable()
    {
        if(ironSpawnPoint == null)
            treeSpawnPoint.Disable(index);

        else ironSpawnPoint.Disable(index);
    }
}
