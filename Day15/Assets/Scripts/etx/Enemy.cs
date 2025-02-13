//using System;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class Enemy : MonoBehaviour
{

    public DropTable DropTable;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.X)) {
            Dead();
        }
    }

    private void Dead()
    {
        GameObject dropItemPrefab = DropTable.drop_table[Random.Range(0,DropTable.drop_table.Count)];

        Instantiate(dropItemPrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
        //리젠 되는 몬스터의 경우 비활성화 처리를 해준다.
    }
}
