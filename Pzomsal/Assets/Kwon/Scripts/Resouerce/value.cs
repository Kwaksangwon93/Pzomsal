using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class value : MonoBehaviour
{

    public int index;

    // 자원이 나무 또는 철인가에 따라 아래 하나의 객체는 null로 계속 유지됨.
    // 이에 해당 객체가 null 상태라고 오류 메세지를 유니티 콘솔에 보여주는데, 실행에 문제가 있는 것은 아님.
    public TreeSpawnPoint treeSpawnPoint = null;
    public IronSpawnPoint ironSpawnPoint = null;

    private void OnDisable()
    {
        if(ironSpawnPoint == null)
            treeSpawnPoint.Disable(index);

        else ironSpawnPoint.Disable(index);
    }
}
