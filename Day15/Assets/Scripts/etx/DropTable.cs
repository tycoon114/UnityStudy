using UnityEngine;
using System.Collections.Generic;

//CreateAssetMenu ���� ()�ȿ� fileName,MenuName,order�� ���� �� �� �ִ�.

[CreateAssetMenu(fileName = "DropTable",menuName = "DropTable/drop table",order = 0)]
public class DropTable : ScriptableObject
{
    public List<GameObject> drop_table;
}
