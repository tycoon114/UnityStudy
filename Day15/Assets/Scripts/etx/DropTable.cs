using UnityEngine;
using System.Collections.Generic;

//CreateAssetMenu 설정 ()안에 fileName,MenuName,order를 설정 할 수 있다.

[CreateAssetMenu(fileName = "DropTable",menuName = "DropTable/drop table",order = 0)]
public class DropTable : ScriptableObject
{
    public List<GameObject> drop_table;
}
